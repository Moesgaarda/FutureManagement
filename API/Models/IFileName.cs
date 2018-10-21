namespace API.Models
{
    public interface IFileName
    {
        int Id { get; set; }
        string FileName { get; set; }
        FileData FileData { get; set; }
    }
}