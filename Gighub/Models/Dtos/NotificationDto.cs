using System;

namespace Gighub.Models.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        public GigDto GigDto { get; private set; }
    }
}