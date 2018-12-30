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
using System.Security.Principal;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class EventLogsController : Controller
    {
        private readonly DataContext _context;
        private readonly IEventLogRepository _repo;

        public EventLogsController(DataContext context, IEventLogRepository repo)
        {
            this._context = context;
            this._repo = repo;
        }

        [Authorize(Policy = "EventLogs_View")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllEventLogs()
        {
            List<EventLog> allEventLogs = await _repo.GetAllEventLogs();

            // Reverse to get newest first.
            allEventLogs.Reverse();

            return Ok(allEventLogs);
        }

        [Authorize(Policy = "EventLogs_View")]
        [HttpGet("myEventLogs/{id}", Name = "GetMyEventLogs")]
        public async Task<IActionResult> GetMyEventLogs(int id)
        {
            // TODO Figure out if this is always int, otherwise type check
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            else
            {
                var myEventLogs = await _repo.GetEventLogs(id);
                return Ok(myEventLogs);
            }
        }

        [Authorize(Policy = "EventLogs_View")]
        [HttpGet("{id}", Name = "GetUserEventLogs")]
        public async Task<IActionResult> GetUserEventLog(int userId)
        {
            var myEventLogs = await _repo.GetEventLogs(userId);
            return Ok(myEventLogs);
        }

    }
}