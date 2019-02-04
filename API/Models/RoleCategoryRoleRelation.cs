using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class RoleCategoryRoleRelation
    {

        public int RoleCategoryId { get; set; }
        public RoleCategory RoleCategory {get; set;}
        public int RoleId { get; set; }
        public Role Role {get; set;}       
    }
}