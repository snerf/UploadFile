using Ninject;
using Ninject.Modules;
using Ninject.Web.WebApi;
using System.Web.Configuration;
using System.Web.Http;
using UploadFile.BusinessLogic.Infrastructure;

namespace UploadFile.Web.Util
{
    public static class NinjectDIResolver
    {
        public static void Resolve()
        {
            NinjectModule uploadedFilesDbServiceModule = new UploadedFilesDbServiceNinjectDIModule();
            NinjectModule uploadFileServiceModule = new UploadFileServiceNinjectDIModule();
            NinjectModule servicesModule = new ServiceModule(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            var kernel = new StandardKernel(servicesModule, uploadedFilesDbServiceModule, uploadFileServiceModule);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}