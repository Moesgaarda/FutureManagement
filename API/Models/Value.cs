using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Value
    {
        public Value(int id, string name)
        {
            this.Id = id;
            this.name = name;

        }
        
        [Key]
        public int Id { get; private set; }
        public string name { get; set; }
    }
}