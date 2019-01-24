using System;
using UploadFile.DataAccess.Entities;

namespace UploadFile.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UploadedFiles> UploadedFiles { get; }
        void Save();
    }
}
