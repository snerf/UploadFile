using System;
using UploadFile.DataAccess.EF;
using UploadFile.DataAccess.Entities;
using UploadFile.DataAccess.Interfaces;

namespace UploadFile.DataAccess.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private UploadFileContext db;
        private UploadedFilesRepository uploadedFilesRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new UploadFileContext(connectionString);
        }
        public IRepository<UploadedFiles> UploadedFiles
        {
            get
            {
                return uploadedFilesRepository ?? (uploadedFilesRepository = new UploadedFilesRepository(db));
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
