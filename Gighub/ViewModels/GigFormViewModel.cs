using Gighub.Models;
using System.Collections.Generic;

namespace Gighub.ViewModels
{
    public class GigFormViewModel
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}