using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class ItemPropertyDescription{
        public ItemPropertyDescription(){}

        public ItemPropertyDescription(int id, string description){
            this.Id = id;
            this.Description = description;
        }
        
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        public ItemPropertyName PropertyName { get; set; }
        public Item Item { get; set; }
    }
}
