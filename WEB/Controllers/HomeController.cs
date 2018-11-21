using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return RedirectToAction("Registration", "Account");
        }

        public ActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}