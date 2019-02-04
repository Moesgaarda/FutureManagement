using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class RoleCategory
    {
        public RoleCategory() {
        }
        public RoleCategory(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
        public RoleCategory(string name) {
            this.Name = name;
        }

        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public ICollection<RoleCategoryRoleRelation> RoleCategoryRoleRelations { get; set; }
    }
}