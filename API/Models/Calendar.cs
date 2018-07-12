using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Calendar
    {
        public Calendar(string name){
            Name = name;
        }

        public Calendar(string name, List<CalendarEvent> events){
            Name = name;
            Events = events;
        }

        public int Id { get; }

        [Required]
        public string Name { get; set; }
        public List<CalendarEvent> Events { get; set; }
    }
}