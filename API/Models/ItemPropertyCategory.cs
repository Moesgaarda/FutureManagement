using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class ItemPropertyCategory{
        public ItemPropertyCategory(){}
        public ItemPropertyCategory(int id, string name){
            this.Id = id;
            this.Name = name;
        }

        public ItemPropertyCategory(string name){
            this.Name = name;
        }
        
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
    }
}