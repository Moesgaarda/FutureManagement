using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Calculator
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}