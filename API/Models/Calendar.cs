using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Calendar
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }
        public ICollection<CalendarEvent> Events { get; set; }
    }
}