using Ninject.Modules;
using UploadFile.BusinessLogic.Interfaces;
using UploadFile.BusinessLogic.Services;

namespace UploadFile.Web.Util
{
    public class UploadedFilesDbServiceNinjectDIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUploadedFilesDbService>().To<UploadedFilesDbService>();
        }
    }
}