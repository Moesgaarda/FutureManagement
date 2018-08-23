using System.Collections.Generic;

namespace API.Models
{
    public class FileData
    {
        public int Id { get; set; }
        public byte[] FileHash {get; set; }
        public string FilePath { get; set; }
        public ICollection<TemplateFileDataRelation> Templates { get; set; }
    }
}