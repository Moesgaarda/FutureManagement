using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Dtos.FileDtos;
using API.Enums;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTemplateController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IItemTemplateRepository _repo;
        private readonly UserManager<User> _userManager;
        private readonly IEventLogRepository _eventLogRepo;

        public ItemTemplateController(IItemTemplateRepository repo, DataContext context,
                                     IMapper mapper, UserManager<User> userManager, IEventLogRepository eventLogRepo)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
            _eventLogRepo = eventLogRepo;
        }

        [Authorize(Policy = "ItemTemplates_View")]
        [HttpGet("getAll", Name = "GetItemTemplates")]
        public async Task<IActionResult> GetItemTemplates(){
            var itemTemplates = await _repo.GetItemTemplates();

            var itemTemplatesToReturn = _mapper.Map<List<ItemTemplateForTableDto>>(itemTemplates);

            return Ok(itemTemplatesToReturn);
        }

        [Authorize(Policy = "ItemTemplates_View")]
        [HttpGet("get/{id}", Name = "GetItemTemplate")]
        public async Task<IActionResult> GetItemTemplate(int id){
            ItemTemplate itemTemplate = await _repo.GetItemTemplate(id);

            ItemTemplateForGetDto itemTemplateToReturn = _mapper.Map<ItemTemplateForGetDto>(itemTemplate);

            return Ok(itemTemplateToReturn);
        }

        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpPost("add")]
        public async Task<IActionResult> AddItemTemplate([FromBody]ItemTemplateForAddDto templateDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            List<TemplatePropertyRelation> propertiesToAdd = new List<TemplatePropertyRelation>();
            foreach(ItemPropertyNameForGetDto prop in templateDto.TemplateProperties){
                propertiesToAdd.Add(new TemplatePropertyRelation{
                    PropertyId = prop.Id
                });
            }
            
            List<TemplateFileName> filesToAdd = new List<TemplateFileName>();
            if(templateDto.Files != null){
                for(int i = 0; i < templateDto.Files.Length; i++){
                    filesToAdd.Add(new TemplateFileName{
                        FileData = new FileData{
                            Id = templateDto.Files[i]
                    },
                    FileName = templateDto.FileNames[i]
                    });
                }
            }

            var unitTypeToAdd = new UnitType(
                templateDto.UnitType.Id,
                templateDto.UnitType.Name
            );
            
            var categoryToAdd = new ItemTemplateCategory(
                templateDto.Category.Id,
                templateDto.Category.Name
            );

            var itemTemplateToCreate = new ItemTemplate(
                templateDto.Name,
                unitTypeToAdd,
                templateDto.Description,
                propertiesToAdd,
                templateDto.Parts,
                templateDto.PartOf,
                DateTime.Now,
                templateDto.RevisionedFrom,
                filesToAdd,
                templateDto.LowerLimit,
                categoryToAdd
            );

            bool succes = await _repo.AddItemTemplate(itemTemplateToCreate);

            if(succes){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                succes = await _eventLogRepo.AddEventLog(EventType.Created, "skabelon", itemTemplateToCreate.Name, itemTemplateToCreate.Id, currentUser);
            }

            return succes ? StatusCode(201) : BadRequest();
        }

        [Authorize(Policy = "ItemTemplates_ActivateDeactivate")]
        [HttpPost("activate/{id}", Name = "ActivateItemTemplate")]
        public async Task<IActionResult> ActivateItemTemplate(int id){
            if(id == 0){
                ModelState.AddModelError("Item Template Error","Can not activate template with id 0.");
            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var template = await _repo.GetItemTemplate(id);

            bool result = await _repo.ActivateItemTemplate(template);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Activated, "egenskab", template.Name, template.Id, currentUser);
            }

            return result ? StatusCode(200) : BadRequest();
        }

        [Authorize(Policy = "ItemTemplates_ActivateDeactivate")]
        [HttpPost("deactivate/{id}", Name = "DeactivateItemTemplate")]
        public async Task<IActionResult> DeactivateItemTemplate(int id){
            if(id == 0){
                ModelState.AddModelError("Item Template Error","Can not deactivate template with id 0.");
            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var template = await _repo.GetItemTemplate(id);

            bool result = await _repo.DeactivateItemTemplate(template);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Deactivated, "egenskab", template.Name, template.Id, currentUser);
            }

            return result ? StatusCode(200) : BadRequest();
        }

        [Authorize(Policy = "ItemTemplates_View")]
        [HttpGet("getFiles/{id}", Name = "GetFiles")]
        public async Task<IActionResult> GetFiles(int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            
            var files = await _repo.GetFiles(id);
            var filesToReturn = _mapper.Map<List<FileForTableGetDto>>(files);

            return Ok(filesToReturn);

        }
    }
}
