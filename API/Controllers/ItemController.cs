using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo, DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("getActive")]
        public async Task<IActionResult> GetActiveItems(){
            var items = await _repo.GetActiveItems();
            var itemsToReturn = _mapper.Map<List<ItemForGetDto>>(items);

            return Ok(itemsToReturn);
        }

        [HttpGet("getArchived")]
        public async Task<IActionResult> GetInactiveItems(){
            var items = await _repo.GetInactiveItems();
            var itemsToReturn = _mapper.Map<List<ItemForGetDto>>(items);

            return Ok(itemsToReturn);
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetItems(){
            var items = await _repo.GetAllItems();
            var itemsToReturn = _mapper.Map<List<ItemForGetDto>>(items);

            return Ok(itemsToReturn);
        }
        [HttpGet("get/{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int id){
            Item item = await _repo.GetItem(id);
            ItemForGetDto itemToReturn = _mapper.Map<ItemForGetDto>(item);

            return Ok(itemToReturn);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> EditItem(Item item){
            if(item.Id == 0){
                ModelState.AddModelError("Item Error","Item id can not be 0.");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            bool result = await _repo.EditItem(item);

            return result ? StatusCode(200) : StatusCode(400);
        }

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

            return StatusCode(200);
        }
        [HttpPost("deactivate/{id}", Name = "DeactivateItem")]
        public async Task<IActionResult> DeactivateItem(int id){
            if(id == 0){
                ModelState.AddModelError("Item Error","Can not deactivate item with id 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var template = await _repo.GetItem(id);

            bool result = await _repo.DeactivateItem(template);

            return StatusCode(200);
        }

        [HttpPost("activate/{id}", Name = "ActivateItem")]
        public async Task<IActionResult> ActivateItem(int id){
            if(id == 0){
                ModelState.AddModelError("Item Error","Can not activate item with id 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var template = await _repo.GetItem(id);

            bool result = await _repo.ActivateItem(template);

            return StatusCode(200);
        }

        [HttpPost("add", Name = "AddItem")]
        public async Task<IActionResult> AddItem([FromBody]ItemForAddDto item){
            var itemToCreate = new Item(
                item.Placement,
                item.Amount,
                item.Template,
                item.Order,
                item.CreatedBy,
                item.Properties,
                item.Parts,
                item.PartOf,
                item.IsActive
            ); 

            await _repo.AddItem(itemToCreate);
            return StatusCode(201);
        }
    }
}