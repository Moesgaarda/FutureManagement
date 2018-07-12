using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Models
{
    public class CalendarEvent
    {
        
        [Key]
        public int Id { get; private set; }

        [Required]
        public CalendarEventType EventType { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public bool Repeats { get; set; }
        public int RepeatedInterval { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<User> Participants { get; set; }
    }
}