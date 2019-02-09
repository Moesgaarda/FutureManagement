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
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITemplateCategoryRepository _repo;
        private readonly IEventLogRepository _eventLogRepo;
        private readonly UserManager<User> _userManager;


        public CategoryController(ITemplateCategoryRepository repo,
            IMapper mapper, UserManager<User> userManager, IEventLogRepository eventLogRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
            _eventLogRepo = eventLogRepo;
        }

        [Authorize(Policy = "Categories_View")]
        [HttpGet("getAll", Name = "GetCategorys")]
        public async Task<IActionResult> GetCategorys(){
            var categorys = await _repo.GetCategories();
            var categorysToReturn = _mapper.Map<List<TemplateCategoryForGetDto>>(categorys);

            categorysToReturn.Sort((x, y) => x.Name.CompareTo(y.Name));

            return Ok(categorysToReturn);
        }

        [Authorize(Policy = "Categories_View")]
        [HttpGet("get/{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int id){
            ItemTemplateCategory category = await _repo.GetCategory(id);
            TemplateCategoryForGetDto categoryToReturn = _mapper.Map<TemplateCategoryForGetDto>(category);

            return Ok(categoryToReturn);
        }

        [Authorize(Policy = "Categories_Add")]
        [HttpPost("add", Name = "AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody]TemplateCategoryForAddDto categoryDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var category = new ItemTemplateCategory(
                categoryDto.Name
            );

            if(category.Name == null || category.Name == ""){
                return BadRequest("Kategoriens navn må ikke være tomt");
            }

            if(_repo.DuplicateExists(category.Name)){
                return BadRequest("Denne kategori findes allerede");
            }

            bool result = await _repo.AddCategory(category);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "kategori", category.Name, category.Id, currentUser);
            }

            if(result){
                return StatusCode(201);
            } else {
                return BadRequest("Kunne ikke tilføje kategorien");
            }
        }

        [Authorize(Policy = "Categories_Add")]
        [HttpPost("edit", Name = "EditCategory")]
        public async Task<IActionResult> EditCategory([FromBody]ItemTemplateCategory categoryDto){
            if(categoryDto.Id == 0){
                ModelState.AddModelError("Unit Type Error","Unit Type id cannot be 0.");
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if(categoryDto.Name == null || categoryDto.Name == ""){
                return BadRequest("Kategoriens navn må ikke være tomt");
            }
            var categoryToChange = await _repo.GetCategory(categoryDto.Id);
            bool result = await _repo.EditCategory(categoryToChange, categoryDto);

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                // TODO This logging is incorrent, pls help Andreas
                result = await _eventLogRepo.AddEventLogChange("kategori", categoryDto.Name, categoryDto.Id, currentUser, categoryToChange, categoryDto);
            }

            if(result){
                return StatusCode(200);
            } else {
                return BadRequest("Kunne ikke ændre kategorien");
            }
        }
    }
}
