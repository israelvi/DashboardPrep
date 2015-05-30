using System.Web.Mvc;

namespace Dashboards.Controllers
{
    public class ElectionController : Controller
    {
        // GET: Election
        public ActionResult Global()
        {
            return View();
        }

        public ActionResult District()
        {
            return View();
        }

        public ActionResult Region()
        {
            return View();
        }
    }
}