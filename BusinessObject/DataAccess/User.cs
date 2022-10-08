using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class User
    {
        public User()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte? Enabled { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
