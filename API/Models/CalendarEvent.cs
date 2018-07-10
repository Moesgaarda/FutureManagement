using System;
using System.Collections.Generic;

namespace API.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public bool Repeats { get; set; }
        public int RepeatedInterval { get; set; }
        public User CreatedBy { get; set; }
        public List<User> Participants { get; set; }
    }
}