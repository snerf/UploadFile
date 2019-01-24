using System.ComponentModel.DataAnnotations;

namespace UploadFile.BusinessLogic.DTO
{
    public class UploadedFilesDTO
    {
        [Required, MaxLength(512)]
        public string FileName { get; set; }
        [Required, MaxLength(1024)]
        public string FilePath { get; set; }
    }
}
