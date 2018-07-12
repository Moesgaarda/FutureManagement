using System;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models
{
    public class EventLog
    {
        [Key]
        public int Id { get; private set; }
        User User;
        DateTime Timestamp;
        String Description;
        EventType Type;
    }
}