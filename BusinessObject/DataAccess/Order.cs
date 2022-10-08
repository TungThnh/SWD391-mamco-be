using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? TimeCreated { get; set; }
        public int? PromoteCodeId { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryType { get; set; }
        public int? TotalPrice { get; set; }
        public int? Status { get; set; }
        public int? MaterialId { get; set; }
        public int? FoodId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Food Food { get; set; }
        public virtual Material Material { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
