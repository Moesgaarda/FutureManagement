using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ChangeTrackingController : Controller
    {
         private readonly DataContext _context;

         public ChangeTrackingController(DataContext context){
             this._context = context;
         }

         public async Task<IActionResult> getAllChanges(){
             throw new NotImplementedException();
         }
    }
}