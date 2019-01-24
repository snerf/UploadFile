using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using UploadFile.DataAccess.Entities;

namespace UploadFile.DataAccess.EF
{
    public partial class UploadFileContext : DbContext
    {
        public UploadFileContext(string connectionString): base(connectionString)
        {
            Database.SetInitializer<UploadFileContext>(new CreateDatabaseIfNotExists<UploadFileContext>());
        }
        
        public virtual DbSet<UploadedFiles> UploadedFiles { get; set; }
    }

    public class UploadFileContextFactory : IDbContextFactory<UploadFileContext>
    {
        public UploadFileContext Create()
        {
            return new UploadFileContext("DefaultConnection");
        }
    }
}