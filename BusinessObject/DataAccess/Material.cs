using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Material
    {
        public Material()
        {
            Orders = new HashSet<Order>();
        }

        public int MaterialId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public int? Status { get; set; }
        public int? MaterialTypeId { get; set; }

        public virtual MaterialType MaterialType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
