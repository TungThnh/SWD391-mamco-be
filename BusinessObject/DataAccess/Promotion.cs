using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Promotion
    {
        public Promotion()
        {
            Customers = new HashSet<Customer>();
        }

        public int PromotionId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? Status { get; set; }
        public int? Percent { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
