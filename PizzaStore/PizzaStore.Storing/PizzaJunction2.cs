using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class PizzaJunction2
    {
        public int JunctionId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingsId { get; set; }
        public bool Active { get; set; }

        public virtual Pizza2 Pizza { get; set; }
        public virtual Toppings2 Toppings { get; set; }
    }
}
