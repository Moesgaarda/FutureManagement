using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Calendar
    {
        public Calendar(){}
        public Calendar(int id, string name)
        {
            this.Id = id;
            this.Name = name;

        }
        
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }
        public ICollection<CalendarEvent> Events { get; set; }
    }
}