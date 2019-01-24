using System;
using System.IO;
using System.Web.Configuration;
using System.Web.Http;
using UploadFile.BusinessLogic.DTO;
using UploadFile.BusinessLogic.Interfaces;
using UploadFile.Web.ViewModels;

namespace UploadFile.Web.Controllers
{
    public class UploadController : ApiController
    {
        private readonly IUploadedFilesDbService uploadedFilesDbService;
        private readonly IUploadFileService uploadFileService;

        public UploadController(IUploadedFilesDbService uploadedFilesDbServiceDI, IUploadFileService uploadFileServiceDI)
        {
            uploadedFilesDbService = uploadedFilesDbServiceDI;
            uploadFileService = uploadFileServiceDI;
        }

        [HttpPost, Route("api/upload")]
        public IHttpActionResult PostFormData()
        {
            try
            {
                UploadFileResponseDTO uploadFileResponseDTO = uploadFileService.UploadFile(WebConfigurationManager.AppSettings["UploadFilePath"]);

                uploadedFilesDbService.UploadFile(new UploadedFilesDTO { FileName = uploadFileResponseDTO.CustomFileName, FilePath = uploadFileResponseDTO.LocalFileName });

                return Ok(new SuccessResponseVM
                {
                    Size = uploadFileResponseDTO.Size,
                    InitialName = uploadFileResponseDTO.InitialName,
                    LocalFileName = uploadFileResponseDTO.LocalFileName,
                    CustomFileName = uploadFileResponseDTO.CustomFileName
                });                
            }
            catch(IOException exception)
            {
                return InternalServerError(exception);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
