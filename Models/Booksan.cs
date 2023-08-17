using System;
using System.Collections.Generic;

#nullable disable

namespace Gosport.Models
{
    public partial class Booksan
    {
        public int Id { get; set; }
        public int? Score { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public int? BookingId { get; set; }
        public int? SanbongId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Sanbong Sanbong { get; set; }
    }
}
