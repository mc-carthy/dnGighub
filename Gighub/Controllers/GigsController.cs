using System.Web.Mvc;

namespace Gighub.Controllers
{
    public class GigsController : Controller
    {
        // GET: Gigs
        public ActionResult Create()
        {
            return View();
        }
    }
}