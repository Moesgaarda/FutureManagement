using System;
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
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo, DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet()]
        public Task<IActionResult> GetAllActiveUsers()
        {
            throw new NotImplementedException();

        }
        [HttpGet("inactive")]
        public Task<IActionResult> GetAllInactiveUsers()
        {
            throw new NotImplementedException();

        }
        [HttpGet("get/{id}", Name = "GetUser")]
        public Task<IActionResult> GetUser(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("editRole")]
        public Task<IActionResult> EditUserRole(User User)
        {
            throw new NotImplementedException();
        }
        [HttpPost("addRoles")]
        public Task<IActionResult> AddNewRoles()
        {
            throw new NotImplementedException();

        }
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