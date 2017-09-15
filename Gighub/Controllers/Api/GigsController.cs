using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var currentUserId = User.Identity.GetUserId();

            var gig = _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == currentUserId);

            if (gig.IsCancelled)
            {
                return NotFound();
            }

            gig.IsCancelled = true;

            var notification = new Notification(NotificationType.GigCancelled, gig);

            foreach (var attendee in gig.Attendances.Select(a => a.Attendee))
            {
                attendee.Notifiy(notification);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
