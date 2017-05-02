using System.Web.Mvc;

namespace CRMContactForm.Controllers
{
    /// <summary>
    /// Контроллер "О проекте".
    /// </summary>
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
