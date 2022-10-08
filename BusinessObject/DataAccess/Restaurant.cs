using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Restaurant
    {
        public int ResId { get; set; }
        public string Name { get; set; }
        public int? ComboId { get; set; }
        public int? FoodId { get; set; }
        public string ListFood { get; set; }
        public string Address { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public int? RatingId { get; set; }

        public virtual Combo Combo { get; set; }
        public virtual Food Food { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual User User { get; set; }
    }
}
