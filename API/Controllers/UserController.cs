using System;
using System.Threading.Tasks;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IItemRepository _repo;
        public UserController(IItemRepository repo, DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllUsers(){
            throw new NotImplementedException();
            
        }
        [HttpGet("get/{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id){
            throw new NotImplementedException();
        }   
        [HttpPost("editRole")]
        public async Task<IActionResult> EditUserRole(User User){
            throw new NotImplementedException();
        }
        [HttpPost("addRoles")]
        public async Task<IActionResult> AddNewRoles(){
            throw new NotImplementedException();

        }
        [HttpPost("edit")]
        public async Task<IActionResult> EditUser(){
            throw new NotImplementedException();

        }
        [HttpPost("archive")]
        public async Task<IActionResult> ArchiveUser(){
            throw new NotImplementedException();

        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser(){
            throw new NotImplementedException();

        }
        [HttpPost("add")]
        public async Task<IActionResult> AddUser(){
            throw new NotImplementedException();

        }


    }
}