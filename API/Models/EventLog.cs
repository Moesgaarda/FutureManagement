using System;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models{
    public class EventLog{
        [Key]
        public int Id {get; set;}
        public DateTime Time {get; set;}
        public User User {get; set;}
        public int UserId {get; set;}
        public string Description {get; set;}
        public string LocalIP {get; set;}
        public EventLog(){
            this.Time = DateTime.Today;
        }
        public EventLog(int id, User user, int userId, string description, string localIP){
            this.Id = id;
            this.User = user;
            this.UserId = userId;
            this.Description = description;
            this.Time = DateTime.Today;
            this.LocalIP = localIP;
        }

        public EventLog(User user, int userId, string description, string localIP){
            this.User = user;
            this.UserId = userId;
            this.Description = description;
            this.Time = DateTime.Now;
            this.LocalIP = localIP;
        }
    }
}