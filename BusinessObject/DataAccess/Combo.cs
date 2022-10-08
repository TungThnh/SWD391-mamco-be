using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Combo
    {
        public Combo()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int ComboId { get; set; }
        public int? FoodId { get; set; }
        public int? Quantity { get; set; }
        public string Name { get; set; }
        public int? TotalPrice { get; set; }
        public int? Status { get; set; }

        public virtual Food Food { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
