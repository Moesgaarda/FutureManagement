using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Calculator
    {
        public Calculator(){}

        public Calculator(int id, string name, int number)
        {
            this.Id = id;
            this.Name = name;
            this.Number = number;

        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }
    }
}