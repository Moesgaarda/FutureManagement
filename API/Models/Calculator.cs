using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Calculator
    {
        public int Id { get; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}