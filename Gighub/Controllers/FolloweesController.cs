using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Gighub.Controllers
{
    public class FolloweesController : Controller
    {
        public ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();

            var followees = _context.Followings
                .Where(f => f.FollowerId == currentUserId)
                .Select(f => f.Followee)
                .ToList();

            return View(followees);
        }
    }
}