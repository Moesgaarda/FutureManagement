using System.Collections.Generic;

namespace API.Dtos
{
    public class RoleCategoryForAddDto
    {
        public string Name { get; set; }
        public ICollection<RoleForGetDto> UserRoles { get; set; }
    }
}