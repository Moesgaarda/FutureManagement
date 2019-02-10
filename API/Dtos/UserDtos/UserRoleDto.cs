using API.Models;

namespace API.Dtos.UserDtos
{
    public class UserRoleDto
    {
        public UserForGetDto User { get; set; }
        public Role Role { get; set; }
    }
}