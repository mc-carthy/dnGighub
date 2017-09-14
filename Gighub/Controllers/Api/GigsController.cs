using Gighub.Models;
using Microsoft.AspNet.Identity;
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

            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == currentUserId);

            if (gig != null)
            {
                return BadRequest("Gig not found or not authorised to cancel this gig.");
            }

            gig.IsCancelled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
