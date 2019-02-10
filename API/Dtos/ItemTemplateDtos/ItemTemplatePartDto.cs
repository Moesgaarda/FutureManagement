using API.Models;

namespace API.Dtos
{
    public class ItemTemplatePartDto
    {
        public ItemTemplatePartForGetDto Part { get; set; }
        public int Amount { get; set; }
    }
}