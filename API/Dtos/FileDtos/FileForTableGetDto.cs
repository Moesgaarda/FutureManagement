namespace API.Dtos.FileDtos
{
    /// <summary>
    /// This DTO is used for showing files in tables.
    /// </summary>
    public class FileForTableGetDto
    {
        public int Id { get; set; }
        public string FileName{ get; set; }
    }
}