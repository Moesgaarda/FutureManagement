using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Change
    {
        [Key]
        public int Id {get; set;}
        public DateTime Time {get; set;}
        public User User {get; set;}
        public int UserId {get; set;}
        public string Description {get; set;}
        public Change(){
            this.Time = DateTime.Now;
        }
        public Change(int id, User user, string description){
            this.Id = id;
            this.User = user;
            this.Description = description;
            this.Time = DateTime.Now;
        }

        public Change(User user, string description){
            this.User = user;
            this.Description = description;
            this.Time = DateTime.Now;
        }
    }
}