using UploadFile.BusinessLogic.DTO;

namespace UploadFile.BusinessLogic.Interfaces
{
    public interface IUploadFileService
    {
        UploadFileResponseDTO UploadFile(string saveFilePath);
    }
}
