using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int gigId)
        {
            var currentUserId = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(a => a.AttendeeId == currentUserId && a.GigId == gigId);

            if (exists)
            {
                return BadRequest("The attendance already exists");
            }

            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = currentUserId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
