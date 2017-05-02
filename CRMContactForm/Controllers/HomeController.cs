using System.Web.Mvc;

namespace CRMContactForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }
    }
}
