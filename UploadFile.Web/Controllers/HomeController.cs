using System.Web.Mvc;

namespace UploadFile.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Upload File";

            return View();
        }
    }
}
