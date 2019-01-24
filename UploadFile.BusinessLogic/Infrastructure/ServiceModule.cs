using Ninject.Modules;
using UploadFile.DataAccess.Interfaces;
using UploadFile.DataAccess.Repositories;

namespace UploadFile.BusinessLogic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
