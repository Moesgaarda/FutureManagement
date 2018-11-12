using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto(string userName, string password){
            this.UserName = userName;
            this.Password = password;
        }
        [Required]
        public string UserName { get; set; }   

        [Required]
        [StringLength(8, MinimumLength=4, ErrorMessage = "You must specify a password between 4 and 8 characters.")]
        public string Password { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}