using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class User : IdentityUser<int>
    {
        public User() { }

        public User(string name, string surname, DateTime birthdate, bool isActive){
            this.Name = name;
            this.Surname = surname;
            this.Birthdate = birthdate;
            this.IsActive = isActive;
        }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserRoleCategoryRelation> UserRoleCategoryRelations { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<EventLog> Changes {get; set;}
    }
}