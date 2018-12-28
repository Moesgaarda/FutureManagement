using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class OrderFileName : IFileName
    {
        [Key]
        public int Id { get; set; }
        public Order Order { get; set; }
        public string FileName { get; set; }
        public FileData FileData { get; set; }
    }
}