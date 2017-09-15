using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gighub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCancelled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.GigCancelled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notifiy(notification);
            }
        }

        public void Modify(string venue, DateTime dateTime, byte genre)
        {
            var notification = Notification.GigUpdated(this, venue, dateTime);
            
            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notifiy(notification);
            }
        }
    }
}