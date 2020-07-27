using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Size1
    {
        public int SizeId { get; set; }
        public bool? Active { get; set; }
        public string Size { get; set; }
        public int Diameter { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }
    }
}
