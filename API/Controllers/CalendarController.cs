using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ICalendarRepository _repo;
        public CalendarController(ICalendarRepository repo, DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        [Authorize(Policy = "Calender_View")]
        [HttpGet("getCalendars")]
        public async Task<IActionResult> GetCalendars(){
            var calendars = await _repo.GetCalendars();

            return Ok(calendars);
        }

        [Authorize(Policy = "Calender_View")]
        [HttpGet("getCalendarEvents/{id}")]
        public async Task<IActionResult> GetCalendarEvents(int calendarId){
            var calendarEvents = await _repo.GetCalendarEvents(calendarId);
            return Ok(calendarEvents);
        }

        [Authorize(Policy = "Calender_Add")]
        [HttpPost("addCalendar")]
        public Task<IActionResult> AddCalendar(){
            throw new NotImplementedException();
        }
    }
}