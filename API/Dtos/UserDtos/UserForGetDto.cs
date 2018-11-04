using System;
using API.Models;
using System.Collections.Generic;

namespace API.Dtos
{
    public class UserForGetDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set;}
        public string Surname{ get; set; }
        public List<UserUserRoleRelation> Roles { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
    }
}