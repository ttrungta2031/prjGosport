using System;
using System.Collections.Generic;

#nullable disable

namespace Gosport.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Sanbongs = new HashSet<Sanbong>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Sanbong> Sanbongs { get; set; }
    }
}
