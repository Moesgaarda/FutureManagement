using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class CustomerType{
        public CustomerType(){}
        public CustomerType(int id, string name){
            this.Id = id;
            this.Name = name;
        }
        
        public CustomerType(string name){
            this.Name = name;
        }

        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
    }
}