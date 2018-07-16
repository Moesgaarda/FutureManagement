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

        [HttpGet("{id}", Name = "GetItemTemplate")]
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
        public async Task<bool> EditItemTemplate(ItemTemplate template){
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteItemTemplate(ItemTemplate template){
            throw new NotImplementedException();
        }
    }
}