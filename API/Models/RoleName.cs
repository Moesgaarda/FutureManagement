using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class RoleName
    {
        public RoleName() {

        }
        public RoleName(int id, string name, ICollection<UserRole> userRoles) {
            this.Id = id;
            this.Name = name;
            this.UserRoles = userRoles;
        }
        public RoleName(string name, ICollection<UserRole> userRoles) {
            this.Name = name;
            this.UserRoles = userRoles;
        }

        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public ICollection<UserRole> UserRoles { get; set; }
    }
}