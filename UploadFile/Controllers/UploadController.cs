using Data.Access;
using Data.Models;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace PharmNet.Controllers
{
    public class UploadController : ApiController
    {
        private readonly UploadFilesAccess accessInstance = new UploadFilesAccess();

        [HttpPost, Route("api/upload")]
        public async Task<IHttpActionResult> PostFormData()
        {
            long? size = null;
            string initialFileName = string.Empty;
            string localFileName = string.Empty;
            string filePath = string.Empty;

            try
            {
                string root = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["UploadFilePath"]);

                if(!Directory.Exists(root)) Directory.CreateDirectory(root);

                var provider = new MultipartFormDataStreamProvider(root);

                var result = await Request.Content.ReadAsMultipartAsync(provider);

                string customFileName = provider.FormData["fileName"];

                foreach (MultipartFileData file in provider.FileData)
                {
                    initialFileName = file.Headers.ContentDisposition.FileName;
                    localFileName = file.LocalFileName;
                    filePath = Path.Combine(root, localFileName + GetFileExtension(initialFileName));
                    
                    File.Move(localFileName, filePath);

                    FileInfo fi = new FileInfo(filePath);
                    size = fi.Length;
                }

                UploadedFiles model = new UploadedFiles
                {
                    FileName = customFileName,
                    FilePath = filePath,
                    InsertDate = DateTime.Now
                };

                accessInstance.Add(model);

                return Ok(new { size = size, initialName = initialFileName,  localFileName = localFileName, customFileName = customFileName });                
            }
            catch(SqlException)
            {
                DeleteFile(filePath);
                return BadRequest("Не удалось сохранить, в БД, данные о загруженном файле");
            }
            catch(IOException exception)
            {
                return InternalServerError(exception);
            }
            catch (Exception exception)
            {
                DeleteFile(filePath);
                return BadRequest(exception.Message);
            }
            finally
            {
                if (accessInstance != null) accessInstance.Dispose();
            }
        }

        private string GetFileExtension(string fullFileName)
        {
            return fullFileName.Substring(fullFileName.LastIndexOf('.')).Replace("\"", "");
        }

        private void DeleteFile(string filePath)
        {
            if (!filePath.Equals(string.Empty)) File.Delete(filePath);
        }
    }
}
