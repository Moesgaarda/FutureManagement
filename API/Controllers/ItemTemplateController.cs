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

        [AllowAnonymous]
        [HttpGet("get/{id}", Name = "GetItemTemplate")]
        public async Task<IActionResult> GetItemTemplate(int id){
            ItemTemplate itemTemplate = await _repo.GetItemTemplate(id);

            ItemTemplateForGetDto itemTemplateToReturn = _mapper.Map<ItemTemplateForGetDto>(itemTemplate);

            return Ok(itemTemplateToReturn);
        }

        [AllowAnonymous]
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
                templateDto.RevisionId,
                templateDto.Created,
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

        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpPost("addProperty", Name = "AddPropertyName")]
        public async Task<IActionResult> AddPropertyName([FromBody]ItemPropertyNameForAddDto propertyDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var itemPropertyName = new ItemPropertyName(
                propertyDto.Name
            );

            bool result = await _repo.AddPropertyName(itemPropertyName);

            if(propertyDto.Name == null){
                return BadRequest("Property name cannot be null.");
            }

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "egenskab", itemPropertyName.Name, itemPropertyName.Id, currentUser);
            }

            return result ? StatusCode(201) : BadRequest();
        }

        
        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpPost("addCategory", Name = "AddTemplateCategory")]
        public async Task<IActionResult> AddTemplateCategory([FromBody]TemplateCategoryForAddDto categoryDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var category = new ItemTemplateCategory(
                categoryDto.Name
            );

            bool result = await _repo.AddTemplateCategory(category);

            if(category.Name == null){
                return BadRequest("Category name cannot be null.");
            }

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "kategori", category.Name, category.Id, currentUser);
            }

            return result ? StatusCode(201) : BadRequest();
        }

        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpGet("getTemplateCategories", Name = "GetTemplateCategories")]
        public async Task<IActionResult> GetTemplateCategories(){
            var categories = await _repo.GetTemplateCategories();
            var categoriesToReturn = _mapper.Map<List<TemplateCategoryForGetDto>>(categories);

            categoriesToReturn.Sort((x, y) => x.Name.CompareTo(y.Name));

            return Ok(categoriesToReturn);
        }

        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpPost("addUnitType", Name = "AddUnitType")]
        public async Task<IActionResult> AddUnitType([FromBody]UnitTypeForAddDto unitTypeDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var unitType = new UnitType(
                unitTypeDto.Name
            );

            bool result = await _repo.AddUnitType(unitType);

            if(unitType.Name == null){
                return BadRequest("UnitType name cannot be null.");
            }

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "mængdeenhed", unitType.Name, unitType.Id, currentUser);
            }

            return result ? StatusCode(201) : BadRequest();
        }

        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpGet("getUnitTypes", Name = "GetUnitTypes")]
        public async Task<IActionResult> GetUnitTypes(){
            var unitTypes = await _repo.GetUnitTypes();
            var unitTypesToReturn = _mapper.Map<List<UnitTypeForGetDto>>(unitTypes);

            unitTypesToReturn.Sort((x, y) => x.Name.CompareTo(y.Name));

            return Ok(unitTypesToReturn);
        }

        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpGet("getPropertyNames", Name = "GetPropertyNames")]
        public async Task<IActionResult> GetPropertyNames(){
            var propertyNames = await _repo.GetPropertyNames();
            var PropertyNamesToReturn = _mapper.Map<List<ItemPropertyNameForGetDto>>(propertyNames);

            PropertyNamesToReturn.Sort((x, y) => x.Name.CompareTo(y.Name));

            return Ok(PropertyNamesToReturn);
        }

        [Authorize(Policy = "ItemTemplates_Add")]
        [HttpGet("getPropertyName/{id}", Name = "GetPropertyName")]
        public async Task<IActionResult> GetPropertyName(int id){
            ItemPropertyName propertyName = await _repo.GetPropertyName(id);
            ItemPropertyNameForGetDto propertyNameToReturn = _mapper.Map<ItemPropertyNameForGetDto>(propertyName);

            return Ok(propertyNameToReturn);
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
