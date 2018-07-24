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
        public async Task<IActionResult> GetallActiveItems(){
            throw new NotImplementedException();
        }
        [HttpGet("getArchived")]
        public async Task<IActionResult> GetAllInactiveItems(){
            throw new NotImplementedException();
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllItems(){
            throw new NotImplementedException();
        }
        [HttpGet("get/{id}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int id){
            throw new NotImplementedException();
        }
        [HttpPost("edit")]
        public async Task<IActionResult> EditItem(Item item){
            throw new NotImplementedException();
            // TODO ReturnCode in unit test is to 200, plz change it if the return code isn't 200
        }
         [HttpPost("delete/{id}", Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem(Item item){
            throw new NotImplementedException();
        }
        [HttpPost("deactivate/{id}", Name = "DeactivateItem")]
        public async Task<IActionResult> DeactivateItem(Item item){
            throw new NotImplementedException();
            // TODO ReturnCode in unit test is to 200, plz change it if the return code isn't 200
        }

        [HttpPost("activate/{id}", Name = "ActivateItem")]
        public async Task<IActionResult> ActivateItem(Item item){
            throw new NotImplementedException();
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
                item.IsArchived
            ); 
            await _repo.AddItem(itemToCreate);
            return StatusCode(201);
        }
    }
}