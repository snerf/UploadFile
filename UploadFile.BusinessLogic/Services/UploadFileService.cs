using System.IO;
using System.Web;
using System.Net.Http;
using UploadFile.BusinessLogic.DTO;
using UploadFile.BusinessLogic.Interfaces;
using System.Linq;

namespace UploadFile.BusinessLogic.Services
{
    public class UploadFileService : IUploadFileService
    {
        public UploadFileResponseDTO UploadFile(string saveFilePath)
        {
            UploadFileResponseDTO result = new UploadFileResponseDTO();

            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var httpPostedFile = HttpContext.Current.Request.Files["file"];

                if (httpPostedFile != null)
                {
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath(saveFilePath), httpPostedFile.FileName);

                    httpPostedFile.SaveAs(fileSavePath);

                    FileInfo fi = new FileInfo(fileSavePath);
                    result.Size = fi.Length;
                    result.InitialName = httpPostedFile.FileName;
                    result.LocalFileName = fileSavePath;
                    result.CustomFileName = HttpContext.Current.Request.Form["fileName"];
                }
            }

            return result;
        }
    }
}
