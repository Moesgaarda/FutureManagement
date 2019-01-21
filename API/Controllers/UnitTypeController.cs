using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Dtos.FileDtos;
using API.Enums;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitTypeController
    {
        private readonly IMapper _mapper;
        private readonly IItemTemplateRepository _repo;
        private readonly IEventLogRepository _eventLogRepo;
        private readonly UserManager<User> _userManager;


        public UnitTypeController(IItemTemplateRepository repo,
            IMapper mapper, UserManager<User> userManager, IEventLogRepository eventLogRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
            _eventLogRepo = eventLogRepo;
        }

        [Authorize(Policy = "UnitTypes_View")]
        [HttpGet("getAll", Name = "GetUnitTypes")]
        public async Task<IActionResult> GetUnitTypes(){
            throw new NotImplementedException();
        }

        [Authorize(Policy = "UnitTypes_View")]
        [HttpGet("get/{id}", Name = "GetUnitType")]
        public async Task<IActionResult> GetUnitType(int id){
            throw new NotImplementedException();
        }

        [Authorize(Policy = "UnitTypes_Add")]
        [HttpPost("add", Name = "AddUnitType")]
        public async Task<IActionResult> AddUnitType([FromBody]UnitTypeForAddDto unitTypeDto){
            throw new NotImplementedException();
        }

        [Authorize(Policy = "UnitTypes_Add")]
        [HttpPost("edit", Name = "EditUnitType")]
        public async Task<IActionResult> EditUnitType([FromBody]UnitTypeForEditDto unitTypeDto){
            throw new NotImplementedException();
        }
    }
}