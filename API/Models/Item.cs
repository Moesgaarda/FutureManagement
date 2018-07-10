using System.Collections.Generic;

namespace API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public List<ItemProperty> MyProperty { get; set; }
        public string Placement { get; set; }
        public int Amount { get; set; }
        public ItemTemplate Template { get; set; }
        public Order Order { get; set; }
        public User CreatedBy { get; set; }
        public List<Item> Parts { get; set; }
    }
}