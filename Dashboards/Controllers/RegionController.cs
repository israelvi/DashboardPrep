using System.Web.Mvc;

namespace Dashboards.Controllers
{
    public class RegionController : Controller
    {
        public ActionResult Detail(int corte, int district, int region)
        {
            ViewBag.Corte = corte;
            ViewBag.District = district;
            ViewBag.Region = region;
            if (corte <= 0 || district <= 0 || region <= 0)
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
}