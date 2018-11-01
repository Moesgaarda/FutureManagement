using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class UserRole{
        public UserRole(){}
        public UserRole(int id, string name, List<UserUserRoleRelation> users ){
            this.Id = id;
            this.Name = name;
            this.Users = users;
        }
        
        public UserRole(string name, List<UserUserRoleRelation> users ){
            this.Name = name;
            this.Users = users;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserUserRoleRelation> Users { get; set;}
    }
}