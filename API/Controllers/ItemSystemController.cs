using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ItemSystemController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IItemTemplateRepository _repo;

        public ItemSystemController(IItemTemplateRepository repo, DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("getItemTemplates")]
        public async Task<IActionResult> GetItemTemplates(){
            var itemTemplates = await _repo.GetItemTemplates();

            var itemTemplatesToReturn = _mapper.Map<List<ItemTemplateForTableDto>>(itemTemplates);

            return Ok(itemTemplatesToReturn); // TODO Tjek om jeg virker.
        }

        [HttpGet("getItemTemplate/{id}", Name = "GetItemTemplate")]
        public async Task<IActionResult> GetItemTemplate(int id){
            var itemTemplate = await _repo.GetItemTemplate(id);

            var itemTemplateToReturn = _mapper.Map<ItemTemplateForGetDto>(itemTemplate);

            return Ok(itemTemplateToReturn); // TODO Tjek om jeg virker.
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItemTemplate([FromBody]ItemTemplateForAddDto templateDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var itemTemplateToCreate = new ItemTemplate(
                templateDto.Name,
                templateDto.UnitType,
                templateDto.Description,
                templateDto.Properties,
                templateDto.Parts,
                templateDto.Files
            );

            await _repo.AddItemTemplate(itemTemplateToCreate);

            return StatusCode(201);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditItemTemplate([FromBody]ItemTemplate template){
            if(template.Id == 0){
                ModelState.AddModelError("Item Template Error","Template id can not be 0.");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var itemTemplateToEdit = new ItemTemplate(
                template.Id,
                template.Name,
                template.UnitType,
                template.Description,
                template.Properties,
                template.Parts,
                template.Files
            );

            await _repo.EditItemTemplate(itemTemplateToEdit);

            return StatusCode(200);
        }
        [HttpPost("delete/{id}", Name = "DeleteItemTemplate")]
        public async Task<IActionResult> DeleteItemTemplate(int id){
            if(id == 0){
                ModelState.AddModelError("Item Template Error","Can not delete template with id 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            await _repo.DeleteItemTemplate(id);

            return StatusCode(200);
        }

        [HttpPost("addProperty", Name = "AddPropertyTemplate")]
        public async Task<IActionResult> AddPropertyTemplate([FromBody]ItemProperty propertyDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var itemTemplatePropertyToCreate = new ItemProperty(
                propertyDto.Name
            );

            await _repo.AddPropertyTemplate(itemTemplatePropertyToCreate);

            return StatusCode(201);
        }
    }
}