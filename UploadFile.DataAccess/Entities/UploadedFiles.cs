using System.ComponentModel.DataAnnotations;

namespace UploadFile.DataAccess.Entities
{
    public class UploadedFiles
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required, MaxLength(512)]
        public string FileName { get; set; }
        [Required, MaxLength(1024)]
        public string FilePath { get; set; }
        public System.DateTime InsertDate { get; set; }
    }
}
