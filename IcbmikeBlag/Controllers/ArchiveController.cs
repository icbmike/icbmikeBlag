using System.Web.Mvc;
using IcbmikeBlag.Models.Archive;

namespace IcbmikeBlag.Controllers
{
    public class ArchiveController : Controller
    {
        public ActionResult Index()
        {
            var model = new ArchiveModel();

            return View(model);
        }
    }
}