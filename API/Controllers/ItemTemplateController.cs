using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Dtos.FileDtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ItemTemplateController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IItemTemplateRepository _repo;

        public ItemTemplateController(IItemTemplateRepository repo, DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "ItemTemplates_View_All")]
        [HttpGet("getAll", Name = "GetItemTemplates")]
        public async Task<IActionResult> GetItemTemplates(){
            var itemTemplates = await _repo.GetItemTemplates();

            var itemTemplatesToReturn = _mapper.Map<List<ItemTemplateForTableDto>>(itemTemplates);

            return Ok(itemTemplatesToReturn);
        }

        [Authorize(Policy = "ItemTemplates_View_Details")]
        [HttpGet("get/{id}", Name = "GetItemTemplate")]
        public async Task<IActionResult> GetItemTemplate(int id){
            ItemTemplate itemTemplate = await _repo.GetItemTemplate(id);

            ItemTemplateForGetDto itemTemplateToReturn = _mapper.Map<ItemTemplateForGetDto>(itemTemplate);
            itemTemplateToReturn.Parts = _mapper.Map<List<ItemTemplatePartDto>>(itemTemplate.Parts);
            itemTemplateToReturn.TemplateProperties = _mapper.Map<List<TemplatePropertyForGetDto>>(itemTemplate.TemplateProperties);
            itemTemplateToReturn.PartOf = _mapper.Map<List<ItemTemplatePartOfDto>>(itemTemplate.PartOf);
            itemTemplateToReturn.Files = _mapper.Map<List<TemplateFileNameForGetDto>>(itemTemplate.Files);

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
            for(int i = 0; i < templateDto.Files.Length; i++){
                filesToAdd.Add(new TemplateFileName{
                    FileData = new FileData{
                        Id = templateDto.Files[i]
                    },
                    FileName = templateDto.FileNames[i]
                    
                });
            }

            var itemTemplateToCreate = new ItemTemplate(
                templateDto.Name,
                templateDto.UnitType,
                templateDto.Description,
                propertiesToAdd,
                templateDto.Parts,
                templateDto.PartOf,
                templateDto.RevisionId,
                templateDto.Created,
                templateDto.RevisionedFrom,
                filesToAdd
            );

            bool succes = await _repo.AddItemTemplate(itemTemplateToCreate);

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

            return result ? StatusCode(201) : BadRequest();
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

            return result ? StatusCode(200) : BadRequest();
        }

        [Authorize(Policy = "ItemTemplates_View_Details")]
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