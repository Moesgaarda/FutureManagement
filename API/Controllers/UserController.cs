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
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo, DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveUsers()
        {
            var users = await _repo.GetAllActiveUsers();
            var usersToReturn = _mapper.Map<List<UserForGetDto>>(users);

            return Ok(usersToReturn);
        }
        [HttpGet("inactive")]
        public async Task<IActionResult> GetAllInactiveUsers()
        {
            var users = await _repo.GetAllInactiveUsers();
            var usersToReturn = _mapper.Map<List<UserForGetDto>>(users);

            return Ok(usersToReturn);

        }
        [HttpGet("get/{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            User user = await _repo.GetUser(id);
            UserForGetDto userToReturn = _mapper.Map<UserForGetDto>(user);

            return Ok(userToReturn);            
        }
             public async Task<IActionResult> AddNewRole(string name)
        {
            var newRole = new UserRole(name);
            bool succes = await _repo.AddRole(newRole);

            return succes ? StatusCode(201) : BadRequest();
        }
        [HttpPost("editRole")]
        public Task<IActionResult> EditUserRole(User User)
        {
            throw new NotImplementedException();
        }
        [HttpPost("addRoles")]
   
        [HttpPost("edit")]
        public Task<IActionResult> EditUser(User user)
        {
            throw new NotImplementedException();

        }
        [HttpPost("deactivate")]
        public Task<IActionResult> DeactivateUser(int id)
        {
            throw new NotImplementedException();

        }
        [HttpPost("activate")]
        public Task<IActionResult> ActivateUser(int id)
        {
            throw new NotImplementedException();

        }
        [HttpPost("delete")]
        public Task<IActionResult> DeleteUser(int id)
        {
            throw new NotImplementedException();

        }
        [HttpPost("add")]
        public Task<IActionResult> AddUser()
        {
            throw new NotImplementedException();

        }


    }
}