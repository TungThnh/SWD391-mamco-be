using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Food
    {
        public Food()
        {
            Combos = new HashSet<Combo>();
            Orders = new HashSet<Order>();
            Restaurants = new HashSet<Restaurant>();
        }

        public int FoodId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public int? Status { get; set; }
        public int? FoodTypeId { get; set; }

        public virtual FoodType FoodType { get; set; }
        public virtual ICollection<Combo> Combos { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
