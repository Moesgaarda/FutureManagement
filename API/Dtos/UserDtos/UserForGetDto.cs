using System;
using API.Models;
using System.Collections.Generic;
using API.Dtos.UserDtos;

namespace API.Dtos
{
    public class UserForGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set;}
        public string Surname{ get; set; }
        public ICollection<UserRoleDto> UserRoles { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
    }
}