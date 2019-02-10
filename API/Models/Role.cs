using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class Role : IdentityRole<int>
    {
        public Role() {

        }

        public Role(string displayName) {
            this.DisplayName = displayName;
        }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleCategoryRoleRelation> RoleCategoryRoleRelations { get; set; }
        public string DisplayName{get; set;}
        
    }
}