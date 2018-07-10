using System.Collections.Generic;

namespace API.Models
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CalendarEvent> Events { get; set; }
    }
}