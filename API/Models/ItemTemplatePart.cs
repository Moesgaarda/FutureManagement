namespace API.Models
{
    public class ItemTemplatePart
    {
        public int TemplateId { get; set; }
        public ItemTemplate Template { get; set; }
        public int PartId { get; set; }
        public ItemTemplate Part { get; set; }
    }
}