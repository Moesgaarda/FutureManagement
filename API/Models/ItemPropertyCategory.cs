using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ItemPropertyCategory
    {
        public ItemPropertyCategory(int id, string name){
            Id = id;
            Name = name;
        }
        public ItemPropertyCategory(string name){
            Name = name;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}