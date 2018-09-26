namespace API.Models
{
    public class TemplateFileName
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public ItemTemplate ItemTemplate { get; set; }
        public FileData FileData { get; set; }
    }
}