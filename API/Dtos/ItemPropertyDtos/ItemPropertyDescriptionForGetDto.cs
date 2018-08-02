using API.Models;

namespace API.Dtos
{
    public class ItemPropertyDescriptionForGetDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ItemPropertyNameForGetDto PropertyName { get; set; }
    }
}