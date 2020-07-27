using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Pizza2
    {
        public Pizza2()
        {
            PizzaJunction2 = new HashSet<PizzaJunction2>();
        }

        public int PizzaId { get; set; }
        public int? CrustId { get; set; }
        public int? SizeId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Crust2 Crust { get; set; }
        public virtual Size2 Size { get; set; }
        public virtual ICollection<PizzaJunction2> PizzaJunction2 { get; set; }
    }
}
