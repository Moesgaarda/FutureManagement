namespace API.Models
{
    public class TemplateFileName : IFileName
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public FileData FileData { get; set; }
        public ItemTemplate ItemTemplate { get; set; }
    }
}