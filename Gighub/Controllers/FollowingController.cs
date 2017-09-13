using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var currentUserId = User.Identity.GetUserId();

            var exists = _context.Followings.Any(f => f.FollowerId == currentUserId && f.FolloweeId == followingDto.FolloweeId);

            if (exists)
            {
                return BadRequest("Following already exists");
            }

            var following = new Following
            {
                FollowerId = currentUserId,
                FolloweeId = followingDto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
