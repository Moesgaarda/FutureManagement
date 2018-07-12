using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Value
    {
        [Key]
        public int Id { get; private set; }
        public string name {get; set;}
    }
}