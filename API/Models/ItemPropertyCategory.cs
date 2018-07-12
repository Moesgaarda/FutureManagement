using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ItemPropertyCategory
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
    }
}