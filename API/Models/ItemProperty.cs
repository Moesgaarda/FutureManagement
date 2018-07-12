using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ItemProperty
    {
        [Key]
        public int Id { get; private set; }

        public string Description { get; set; }
    }
}