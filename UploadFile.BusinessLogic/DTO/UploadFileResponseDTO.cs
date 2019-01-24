namespace UploadFile.BusinessLogic.DTO
{
    public class UploadFileResponseDTO
    {
        public long? Size { get; set; }
        public string InitialName { get; set; }
        public string LocalFileName { get; set; }
        public string CustomFileName { get; set; }
    }
}
