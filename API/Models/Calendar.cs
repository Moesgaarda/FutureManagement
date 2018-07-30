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

        public Calendar(string name)
        {
            this.Name = name;
        }


        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<CalendarEvent> Events { get; set; }
    }
}