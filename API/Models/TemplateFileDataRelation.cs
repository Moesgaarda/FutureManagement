namespace API.Models
{
    public class TemplateFileDataRelation
    {
        public int TemplateId { get; set; }
        public ItemTemplate Template { get; set; }
        public int FileDataId { get; set; }
        public FileData File { get; set; }
    }
}