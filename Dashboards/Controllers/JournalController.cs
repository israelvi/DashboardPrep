using System.Web.Mvc;

namespace Dashboards.Controllers
{
    public class JournalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Region(int district)
        {
            ViewBag.District = district;
            if (district <= 0)
                return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult Detail(int district, int region)
        {
            ViewBag.District = district;
            ViewBag.Region = region;
            if (district <= 0 || region <= 0)
                return RedirectToAction("Index", "Home");

            return View();
        }

    }
}