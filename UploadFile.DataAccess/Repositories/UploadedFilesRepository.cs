using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UploadFile.DataAccess.EF;
using UploadFile.DataAccess.Entities;
using UploadFile.DataAccess.Interfaces;

namespace UploadFile.DataAccess.Repositories
{
    public class UploadedFilesRepository : IRepository<UploadedFiles>
    {
        private UploadFileContext db;

        public UploadedFilesRepository(UploadFileContext context)
        {
            this.db = context;
        }

        public IQueryable<UploadedFiles> GetAll()
        {
            return db.UploadedFiles;
        }

        public UploadedFiles Get(int id)
        {
            return db.UploadedFiles.Find(id);
        }

        public void Create(UploadedFiles book)
        {
            db.UploadedFiles.Add(book);
        }

        public void Update(UploadedFiles book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<UploadedFiles> Find(Func<UploadedFiles, Boolean> predicate)
        {
            return db.UploadedFiles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UploadedFiles uploadedFile = db.UploadedFiles.Find(id);
            if (uploadedFile != null)
            {
                db.UploadedFiles.Remove(uploadedFile);
            }
        }
    }
}
