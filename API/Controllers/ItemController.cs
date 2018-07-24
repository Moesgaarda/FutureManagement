using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

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
        public async Task<IActionResult> GetAllArchivedItems(){
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
        [HttpPost("create")]
        public async Task<IActionResult> CreateItem(Item item){
            throw new NotImplementedException();
        }
        [HttpPost("edit")]
        public async Task<IActionResult> EditItem(Item item){
            throw new NotImplementedException();
        }
         [HttpPost("delete/{id}", Name = "DeleteItem")]
        public async Task<IActionResult> DeleteItem(Item item){
            throw new NotImplementedException();
        }
        [HttpPost("Archive/{id}", Name = "ArchieveItem")]
        public async Task<IActionResult> ArchiveItem(Item item){
            throw new NotImplementedException();
        }
        [HttpPost("add", Name = "AddItem")]
        public async Task<IActionResult> AddItem([FromBody]Item item){
            throw new NotImplementedException();
        }
    }
}