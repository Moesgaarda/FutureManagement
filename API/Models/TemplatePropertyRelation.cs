namespace API.Models
{
    public class TemplatePropertyRelation
    {
        public int TemplateId { get; set; }
        public ItemTemplate Template { get; set; }
        public int PropertyId { get; set; }
        public ItemPropertyName Property { get; set; }
    }
}