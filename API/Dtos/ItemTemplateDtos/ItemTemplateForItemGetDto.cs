using API.Models;

namespace API.Dtos
{
    public class ItemTemplateForItemGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UnitType UnitType {get; set;}
    }
}