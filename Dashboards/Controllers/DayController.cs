using System.Web.Mvc;

namespace Dashboards.Controllers
{
    public class DayController : Controller
    {
        // GET: Day
        public ActionResult District(int corte)
        {
            ViewBag.Corte = corte;
            if (corte <= 0)
                return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult Region(int corte, int district)
        {
            ViewBag.Corte = corte;
            ViewBag.District = district;
            if (corte <= 0 || district <= 0)
                return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult SecondClosure()
        {
            return View();
        }

        public ActionResult ThirdClosure()
        {
            return View();
        }
        
        public ActionResult Closure()
        {
            return View();
        }
    }
}