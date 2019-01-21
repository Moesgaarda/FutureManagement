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
    public class UnitTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitTypeRepository _repo;
        private readonly IEventLogRepository _eventLogRepo;
        private readonly UserManager<User> _userManager;


        public UnitTypeController(IUnitTypeRepository repo,
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
            var unitTypes = await _repo.GetUnitTypes();
            var unitTypesToReturn = _mapper.Map<List<UnitTypeForGetDto>>(unitTypes);

            unitTypesToReturn.Sort((x, y) => x.Name.CompareTo(y.Name));

            return Ok(unitTypesToReturn);
        }

        [Authorize(Policy = "UnitTypes_View")]
        [HttpGet("get/{id}", Name = "GetUnitType")]
        public async Task<IActionResult> GetUnitType(int id){
            UnitType unitType = await _repo.GetUnitType(id);
            UnitTypeForGetDto unitTypeToReturn = _mapper.Map<UnitTypeForGetDto>(unitType);

            return Ok(unitTypeToReturn);
        }

        [Authorize(Policy = "UnitTypes_Add")]
        [HttpPost("add", Name = "AddUnitType")]
        public async Task<IActionResult> AddUnitType([FromBody]UnitTypeForAddDto unitTypeDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var unitType = new UnitType(
                unitTypeDto.Name
            );

            bool result = await _repo.AddUnitType(unitType);

            if(unitType.Name == null){
                return BadRequest("UnitType name cannot be null.");
            }

            if(result){
                User currentUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                result = await _eventLogRepo.AddEventLog(EventType.Created, "mængdeenhed", unitType.Name, unitType.Id, currentUser);
            }

            return result ? StatusCode(201) : BadRequest();
        }

        [Authorize(Policy = "UnitTypes_Add")]
        [HttpPost("edit", Name = "EditUnitType")]
        public async Task<IActionResult> EditUnitType([FromBody]UnitTypeForEditDto unitTypeDto){
            throw new NotImplementedException();
        }
    }
}