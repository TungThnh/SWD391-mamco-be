using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ListFood { get; set; }
        public int? Price { get; set; }
        public byte? Status { get; set; }
    }
}
