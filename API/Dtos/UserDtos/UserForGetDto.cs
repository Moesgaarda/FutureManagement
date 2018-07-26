using API.Models;

namespace API.Dtos.UserDtos
{
    public class UserForGetDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set;}
        public string SurName{ get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}