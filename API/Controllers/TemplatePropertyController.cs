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
    public class TemplatePropertyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITemplatePropertyRepository _repo;
        private readonly IEventLogRepository _eventLogRepo;
        private readonly UserManager<User> _userManager;


        public TemplatePropertyController(ITemplatePropertyRepository repo,
            IMapper mapper, UserManager<User> userManager, IEventLogRepository eventLogRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
            _eventLogRepo = eventLogRepo;
        }

        [Authorize(Policy = "TemplateProperties_View")]
        [HttpGet("getAll", Name = "GetTemplateProperties")]
        public async Task<IActionResult> GetTemplateProperties(){
            var propertyNames = await _repo.GetProperties();
            var propertyNamesToReturn = _mapper.Map<List<ItemPropertyNameForGetDto>>(propertyNames);

            propertyNamesToReturn.Sort((x, y) => x.Name.CompareTo(y.Name));

            return Ok(propertyNamesToReturn);
        }

        [Authorize(Policy = "TemplateProperties_View")]
        [HttpGet("get/{id}", Name = "GetTemplateProperty")]
        public async Task<IActionResult> GetTemplateProperty(int id){
            ItemPropertyName propertyName = await _repo.GetProperty(id);
            ItemPropertyNameForGetDto propertyNameToReturn = _mapper.Map<ItemPropertyNameForGetDto>(propertyName);

            return Ok(propertyNameToReturn);
        }

        [Authorize(Policy = "TemplateProperties_Add")]
        [HttpPost("add", Name = "AddTemplateProperty")]
        public async Task<IActionResult> AddTemplateProperty([FromBody]ItemPropertyNameForAddDto ItemPropertyNameDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var itemPropertyName = new ItemPropertyName(
                ItemPropertyNameDto.Name
            );

            if(itemPropertyName.Name == null || itemPropertyName.Name == ""){
                return BadRequest("Egenskabens navn må ikke være tom");
            }

            if(_repo.DuplicateExists(itemPropertyName.Name)){
                return BadRequest("Denne egenskab findes allerede");
            }

            bool result = await _repo.AddProperty(itemPropertyName);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "egenskab", itemPropertyName.Name, itemPropertyName.Id, currentUser);
            }

            if(result){
                return StatusCode(201);
            } else{
                return BadRequest("Kunne ikke tilføje egenskaben");
            }
        }

        [Authorize(Policy = "TemplateProperties_Add")]
        [HttpPost("edit", Name = "EditTemplateProperty")]
        public async Task<IActionResult> EditTemplateProperty([FromBody]ItemPropertyName propertyNameDto){
            if(propertyNameDto.Id == 0){
                ModelState.AddModelError("Template Property Error","Template Property id cannot be 0.");
            }
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if(propertyNameDto.Name == null || propertyNameDto.Name == ""){
                return BadRequest("Egenskabens navn må ikke være tom");
            }

            var propertyNameToChange = await _repo.GetProperty(propertyNameDto.Id);
            bool result = await _repo.EditProperty(propertyNameToChange, propertyNameDto);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLogChange("egenskab", propertyNameDto.Name, propertyNameDto.Id, currentUser, propertyNameToChange, propertyNameDto);
            }

            if(result){
                return StatusCode(200);
            } else{
                return BadRequest("Kunne ikke ændre egenskaben");
            }
        }
    }
}
