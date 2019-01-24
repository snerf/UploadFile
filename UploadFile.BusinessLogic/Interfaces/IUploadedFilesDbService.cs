using System.Collections.Generic;
using UploadFile.BusinessLogic.DTO;

namespace UploadFile.BusinessLogic.Interfaces
{
    public interface IUploadedFilesDbService
    {
        void UploadFile(UploadedFilesDTO uploadedFilesDTO);
        List<UploadedFilesDTO> GetUploadedFiles();
        void Dispose();
    }
}
