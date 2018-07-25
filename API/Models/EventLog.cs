using System;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models{
    public class EventLog{
        public EventLog(){}
        public EventLog(int id){
            this.Id = id;

        }
        
        [Key]
        public int Id { get; set; }
        User User;
        DateTime Timestamp;
        String Description;
        EventType Type;
    }
}