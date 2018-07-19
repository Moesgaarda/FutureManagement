using System.ComponentModel.DataAnnotations;

namespace API.Models{
    public class ItemProperty{
        public ItemProperty(){}
        public ItemProperty(int id, string name, string description){
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public ItemProperty(string name){
            this.Name = name;
        }
        
        [Key]
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}

/*
------------- Tilføjelse af nyt template --------------
Navn på property: name

------------- Tilføjelse af ny instans ----------------
Vælger hvilke man vil have (tilknytning af ID), her vises navn
Udfyldelse af description = det de udfylder for instansen (f.eks. malingsfarve)
 */