using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Rating
    {
        public Rating()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }
        public int? Score { get; set; }
        public string Remarks { get; set; }
        public DateTime? DateRecorded { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
