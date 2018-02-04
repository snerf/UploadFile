using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Access
{
    public class UploadFilesAccess: IDisposable
    {
        private readonly UploadFileEntities context = new UploadFileEntities();

        public void Add(UploadedFiles entity)
        {
            if (entity != null)
            {
                context.UploadedFiles.Add(entity);
                context.SaveChanges();
            }
        }

        public UploadedFiles Get(int Id)
        {
            return context.UploadedFiles.FirstOrDefault(f => f.Id == Id);
        }

        public List<UploadedFiles> GetAll()
        {
            return context.UploadedFiles.ToList();
        }

        public void Modify(UploadedFiles item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            UploadedFiles toDeleteObject = context.UploadedFiles.FirstOrDefault(w => w.Id == Id);
            context.UploadedFiles.Remove(toDeleteObject);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
