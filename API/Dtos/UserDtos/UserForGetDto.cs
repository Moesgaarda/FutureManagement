using System;
using API.Models;
using System.Collections.Generic;

namespace API.Dtos
{
    /// <summary>
    /// This DTO is used for user get requests and should contain
    /// the essential information about a user.
    /// </summary>
    public class UserForGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set;}
        public string Surname{ get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
    }
}