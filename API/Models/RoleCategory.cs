using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class RoleCategory
    {
        public RoleCategory() {
        }
        public RoleCategory(int id, string name, ICollection<RoleCategoryRoleRelation> roleCategoryRoleRelations) {
            this.Id = id;
            this.Name = name;
        }
        public RoleCategory(string name, ICollection<RoleCategoryRoleRelation> roleCategoryRoleRelations) {
            this.Name = name;
        }

        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public ICollection<RoleCategoryRoleRelation> RoleCategoryRoleRelations { get; set; }
    }
}