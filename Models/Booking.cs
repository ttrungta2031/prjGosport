using System;
using System.Collections.Generic;

#nullable disable

namespace Gosport.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Booksans = new HashSet<Booksan>();
        }

        public int Id { get; set; }
        public double? Total { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public DateTime? CreateDay { get; set; }
        public bool? Status { get; set; }
        public int? Sanbongid { get; set; }
        public int? CustomerId { get; set; }

        public virtual User Customer { get; set; }
        public virtual Sanbong Sanbong { get; set; }
        public virtual ICollection<Booksan> Booksans { get; set; }
    }
}
