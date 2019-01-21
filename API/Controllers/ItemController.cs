using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using API.Enums;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IItemRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly IEventLogRepository _eventLogRepo;
        public ItemController(IItemRepository repo, DataContext context, IMapper mapper, 
                                UserManager<User> userManager, IEventLogRepository eventLogRepo){
            _context = context;
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
            _eventLogRepo = eventLogRepo;
        }

        [Authorize(Policy = "Items_View")]
        [HttpGet("getActive")]
        public async Task<IActionResult> GetActiveItems(){
            var items = await _repo.GetActiveItems();
            var itemsToReturn = _mapper.Map<List<ItemForTableGetDto>>(items);

            return Ok(itemsToReturn);
        }

        [HttpGet("hasDependencies/{id}")]
        public async Task<IActionResult> HasDependencies(int id){
            var item = await _repo.GetItem(id);
            var result = _repo.HasDependencies(item);

            return result.Result ? StatusCode(200) : StatusCode(400);
        }

        [Authorize(Policy = "Items_View")]
        [HttpGet("getInactive")]
        public async Task<IActionResult> GetInactiveItems(){
            var items = await _repo.GetInactiveItems();
            var itemsToReturn = _mapper.Map<List<ItemForTableGetDto>>(items);

            return Ok(itemsToReturn);
        }

        [Authorize(Policy = "Items_View")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetItems(){
            var items = await _repo.GetAllItems();
            var itemsToReturn = _mapper.Map<List<ItemForTableGetDto>>(items);

            return Ok(itemsToReturn);
        }

        
        [Authorize(Policy = "Items_View")]
        [HttpGet("getLowInventory")]
        public async Task<IActionResult> GetLowInventory(){
            var items = await _repo.GetActiveItems();
            var loadedItems = _mapper.Map<List<ItemForTableGetDto>>(items);
            var itemsToReturn = new List<ItemForTableGetDto>();

            foreach(ItemForTableGetDto item in loadedItems){
                if(!itemsToReturn.Any(x => x.Template.Id == item.Template.Id)){
                    itemsToReturn.Add(item);
                }
                else
                {
                    itemsToReturn.FirstOrDefault(x => x.Template.Id == item.Template.Id).Amount += item.Amount;
                }
            }
            
            itemsToReturn = itemsToReturn.Where(x => x.Amount < x.Template.LowerLimit).ToList();

            return Ok(itemsToReturn);
        }

        [Authorize(Policy = "Items_View")]
        [HttpGet("get/{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int id){
            Item item = await _repo.GetItem(id);
            ItemForGetDto itemToReturn = _mapper.Map<ItemForGetDto>(item);
            return Ok(itemToReturn);
        }



        [Authorize(Policy = "Items_Edit")]
        [HttpPost("edit")]
        public async Task<IActionResult> EditItem([FromBody]Item item){
            if(item.Id == 0){
                ModelState.AddModelError("Item Error","Item id can not be 0.");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            
            var itemToChange = await _context.Items.FirstAsync(x => x.Id == item.Id);
            bool result = await _repo.EditItem(item, itemToChange);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLogChange("genstand", item.Template.Name, item.Id, currentUser, item, itemToChange);
            }

            return result ? StatusCode(200) : StatusCode(400);
        }

        [Authorize(Policy = "Items_Delete")]
        [HttpPost("delete/{id}", Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem(int id){
            if(id == 0){
                ModelState.AddModelError("Item Error","Can not delete item with id 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var item = await _repo.GetItem(id);

            bool result = await _repo.DeleteItem(item);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Deleted, "genstand", item.Template.Name, item.Id, currentUser);
            }

            return result ? StatusCode(200) : BadRequest();
        }

        [Authorize(Policy = "Items_ActivateDeactivate")]
        [HttpPost("deactivate/{id}", Name = "DeactivateItem")]
        public async Task<IActionResult> DeactivateItem(int id){
            if(id == 0){
                ModelState.AddModelError("Item Error","Can not deactivate item with id 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var item = await _repo.GetItem(id);

            bool result = await _repo.DeactivateItem(item);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Deactivated, "genstand", item.Template.Name, item.Id, currentUser);
            }

            return result ? StatusCode(200) : BadRequest();
        }

        [Authorize(Policy = "Items_ActivateDeactivate")]
        [HttpPost("activate/{id}", Name = "ActivateItem")]
        public async Task<IActionResult> ActivateItem(int id){
            if(id == 0){
                ModelState.AddModelError("Item Error","Can not activate item with id 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var item = await _repo.GetItem(id);

            bool result = await _repo.ActivateItem(item);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Activated, "genstand", item.Template.Name, item.Id, currentUser);
            }

            return result ? StatusCode(200) : BadRequest();
        }

        [Authorize(Policy = "Items_Add")]
        [HttpPost("add", Name = "AddItem")]
        public async Task<IActionResult> AddItem([FromBody]ItemForAddDto item){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            List<ItemItemRelation> partsToAdd = new List<ItemItemRelation>();
            foreach(ItemItemRelationPartOfForGet part in item.Parts){
                partsToAdd.Add(new ItemItemRelation{
                    Part = part.Part,
                    Amount = part.Amount
                });
            }

            foreach(ItemItemRelation itemPart in partsToAdd) {
                var itemToReduce = await _repo.GetItem(itemPart.Part.Id);
                itemToReduce.Amount -= itemPart.Amount;
            }

            var itemToCreate = new Item(
                item.Placement,
                item.Amount,
                item.Template,
                item.Order,
                _userManager.FindByNameAsync(User.Identity.Name).Result,
                item.Properties,
                partsToAdd,
                item.PartOf,
                item.IsActive
            );

            bool result = await _repo.AddItem(itemToCreate);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "genstand", itemToCreate.Template.Name, itemToCreate.Id, currentUser);
            }
            return result ? StatusCode(201) : BadRequest();
        }

        [HttpGet("getPropertyDescription/{id}", Name = "GetPropertyDescription")]
        public async Task<IActionResult> GetPropertyDescriptions(int id){
            List<ItemPropertyDescription> propertyDescription = await _repo.GetPropertyDescriptions(id);
            List<ItemPropertyDescriptionForGetDto> propertyDescriptionToReturn = _mapper.Map<List<ItemPropertyDescriptionForGetDto>>(propertyDescription);

            return Ok(propertyDescriptionToReturn);
        }

        [HttpGet("getAllInstancesInStock/{id}", Name = "GetAllInstancesInStock")]
        public async Task<IActionResult> GetAllInstancesInStock(int id){
            List<Item> items = await _repo.GetAllInstancesInStock(id);

            return Ok(items);
        }
    }
}
