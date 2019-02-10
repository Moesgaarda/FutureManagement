using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IAuthRepository _repo;


        public AuthController(IConfiguration config, 
                            IMapper mapper, UserManager<User> userManager,
                            SignInManager<User> signInManager, RoleManager<Role> roleManager,
                            IAuthRepository repo){
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto){

            var userToCreate = _mapper.Map<User>(userForRegisterDto);
            var rolesToAddToUser = _repo.GetRoles(userForRegisterDto.RoleCategory);

            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

           foreach (var role in rolesToAddToUser) {
                await _userManager.AddToRoleAsync(userToCreate, role.Name);
            }

            var userToReturn = _mapper.Map<UserForGetDto>(userToCreate);

            if(result.Succeeded){
                return CreatedAtRoute("GetUser",
                new { controller = "Users", id = userToCreate.Id }, userToReturn);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto){
            var user = await _userManager.FindByNameAsync(userForLoginDto.UserName);

            if(user.IsActive == false){
                return Unauthorized();
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (result.Succeeded){
                var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.NormalizedUserName == userForLoginDto.UserName.ToUpper());
                var userToReturn = _mapper.Map<UserForGetDto>(appUser);

                return Ok(new{
                    token = GenerateJwtTokenAsync(appUser).Result,
                    user = userToReturn
                });
            }

            return Unauthorized();
        }

        [HttpPost("updateToken")]
        private async Task<IActionResult> UpdateCurrentUserToken(string username)
        {
            // Should be called after the edited user has been saved to Db
            var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
            var userToReturn = _mapper.Map<UserForGetDto>(appUser);

            return Ok(new
            {
                token = GenerateJwtTokenAsync(appUser).Result,
                user = userToReturn
            });
        }
        
        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}