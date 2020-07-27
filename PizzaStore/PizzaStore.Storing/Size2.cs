using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Size2
    {
        public Size2()
        {
            Pizza2 = new HashSet<Pizza2>();
        }

        public int SizeId { get; set; }
        public bool? Active { get; set; }
        public string Size { get; set; }
        public int Diameter { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Pizza2> Pizza2 { get; set; }
    }
}
