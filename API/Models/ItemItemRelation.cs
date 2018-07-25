namespace API.Models
{
    public class ItemItemRelation
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int PartId { get; set; }
        public Item Part { get; set; }
    }
}