using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

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

        [HttpPost("edit")]
        public async Task<IActionResult> EditUser([FromBody]User user)
        {
            if(user.Id == 0){
                ModelState.AddModelError("User Error", "User id can not be 0.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool succes = await _repo.EditUser(user);

            return succes ? StatusCode(200) : BadRequest();

        }
        
        [HttpPost("deactivate/{id}", Name = "DeactivateUser")]
        public async Task<IActionResult> DeactivateUser(int id)
        {
            var user = await _repo.GetUser(id);
            user.IsActive = false;
            var succes = await _repo.DeActivateUser(user);
            return succes ? StatusCode(200) : BadRequest();
        }
        [HttpPost("activate")]
        public async Task<IActionResult> ActivateUser(int id)
        {
            var userActivate = await _repo.GetUser(id);
            userActivate.IsActive = true;
            bool succes = await _repo.ActivateUser(userActivate);
            return succes ? StatusCode(200) : BadRequest();
        }
        [HttpPost("delete/{id}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userDel = await _repo.GetUser(id);
            bool succes = await _repo.DeleteUser(userDel);
            return succes ? StatusCode(200) : BadRequest();

        }
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody]User userToAdd)
        {
            // TODO maybe need to be UserForRegister or something
            bool succes = await _repo.AddUser(userToAdd);
            return succes ? StatusCode(200) : BadRequest();
        }
    public async Task<IActionResult> AddRoleToUser(){
        // TODO implement
        return StatusCode(200);
    }
    public async Task<IActionResult> RemoveRoleFromUser(){
        // TODO implement
        return StatusCode(200);
    }

     [HttpPost("addRole")]
    public async Task<IActionResult> AddNewRole([FromBody]string name)
        {   
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            var newRole = new UserRole(name, null);
            bool succes = await _repo.AddRole(newRole);

            return succes ? StatusCode(201) : BadRequest();
        }


    }
}