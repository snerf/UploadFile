using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UploadFile.BusinessLogic.DTO;
using UploadFile.BusinessLogic.Interfaces;
using UploadFile.DataAccess.Interfaces;

namespace UploadFile.BusinessLogic.Services
{
    public class UploadedFilesDbService : IUploadedFilesDbService
    {
        IUnitOfWork Database { get; set; }

        public UploadedFilesDbService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<UploadedFilesDTO> GetUploadedFiles()
        {
            return Database.UploadedFiles
                .GetAll()
                .AsNoTracking()
                .Select(s => new UploadedFilesDTO { FileName = s.FileName, FilePath = s.FilePath })
                .ToList();
        }

        public void UploadFile(UploadedFilesDTO uploadedFilesDTO)
        {
            Database.UploadedFiles.Create(new DataAccess.Entities.UploadedFiles
            {
                FilePath = uploadedFilesDTO.FilePath,
                FileName = uploadedFilesDTO.FileName,
                InsertDate = DateTime.Now
            });

            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
