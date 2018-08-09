using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ChangeTrackerController : Controller
    {
         private readonly DataContext _context;
         private readonly IChangeTrackerRepository _repo;

         public ChangeTrackerController(DataContext context, IChangeTrackerRepository repo){
             this._context = context;
             this._repo = repo;
         }

        [HttpGet("getAll")]
         public async Task<IActionResult> GetAllChanges(){
             List<Change> allChanges = await _repo.GetAllChanges();

             return Ok(allChanges);
         }

        [HttpGet("{id}", Name = "GetMyChanges")]
         public async Task<IActionResult> GetMyChanges(int id){
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)){
                return Unauthorized();
            }
                
            else{
                var myChanges = await _repo.GetChanges(id);
                return Ok(myChanges);
            }
         }

        [HttpGet("{id}", Name = "GetUserChanges")]
         public async Task<IActionResult> GetUserChanges(int userId){
            var myChanges = await _repo.GetChanges(userId);
            return Ok(myChanges);
         }
    }
}