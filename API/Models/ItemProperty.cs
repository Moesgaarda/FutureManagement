using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ItemProperty
    {
        public ItemProperty(int id, string description){
            Id = id;
            Description = description;
        }
        public ItemProperty(string description){
            Description = description;
        }
        public int Id { get; }
        [Required]
        public string Description { get; set; }
    }
}