using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public byte? Status { get; set; }
        public int? PromotionId { get; set; }

        public virtual Promotion Promotion { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
