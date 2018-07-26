using API.Models;

namespace API.Dtos
{
    public class ItemForTableGetDto
    {
        public int Id { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        public ItemTemplate Template { get; set; }
        public OrderForGetDto Order { get; set; }
    }
}