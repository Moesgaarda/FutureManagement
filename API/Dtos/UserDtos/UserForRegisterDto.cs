using System;
using System.ComponentModel.DataAnnotations;
using API.Models;
using System.Collections.Generic;

namespace API.Dtos
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto(string userName, string password){
            this.UserName = userName;
            this.Password = password;
        }
        [Required]
        public string UserName { get; set; }   

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection <RoleCategory> RoleCategory {get; set;}
    }
}