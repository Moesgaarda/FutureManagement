using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class User{
        public User() { }

        public User(int id, string username, UserRole role, string name, string surname, DateTime birthdate, bool isActive, string email, string phone){
            this.Id = id;
            this.Username = username;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            this.Birthdate = birthdate;
            this.IsActive = isActive;
            this.Email = email;
            this.Phone = phone;
        }

        public User(string username, UserRole role, string name, string surname, DateTime birthdate, bool isActive, string email, string phone){
            this.Username = username;
            this.Role = role;
            this.Name = name;
            this.Surname = surname;
            this.Birthdate = birthdate;
            this.IsActive = isActive;
            this.Email = email;
            this.Phone = phone;
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}