using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Toppings2
    {
        public Toppings2()
        {
            PizzaJunction2 = new HashSet<PizzaJunction2>();
        }

        public int ToppingsId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<PizzaJunction2> PizzaJunction2 { get; set; }
    }
}
