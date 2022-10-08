using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class MaterialType
    {
        public MaterialType()
        {
            Materials = new HashSet<Material>();
        }

        public int MaterialTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
