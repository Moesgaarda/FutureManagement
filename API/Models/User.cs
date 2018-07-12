using System;

namespace API.Models
{
    public class User
    {
        public int Id { get; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
    }
}