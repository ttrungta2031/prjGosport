using System;
using System.Collections.Generic;

#nullable disable

namespace Gosport.Models
{
    public partial class Sanbong
    {
        public Sanbong()
        {
            Bookings = new HashSet<Booking>();
            Booksans = new HashSet<Booksan>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlImage { get; set; }
        public string Scope { get; set; }
        public double? Price { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDay { get; set; }
        public bool Status { get; set; }
        public int? Owner { get; set; }

        public virtual User OwnerNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Booksan> Booksans { get; set; }
    }
}
