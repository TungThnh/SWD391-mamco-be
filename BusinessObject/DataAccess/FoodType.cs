using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class FoodType
    {
        public FoodType()
        {
            Foods = new HashSet<Food>();
        }

        public int FoodTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
