using Ninject.Modules;
using UploadFile.BusinessLogic.Interfaces;
using UploadFile.BusinessLogic.Services;

namespace UploadFile.Web.Util
{
    public class UploadFileServiceNinjectDIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUploadFileService>().To<UploadFileService>();
        }
    }
}