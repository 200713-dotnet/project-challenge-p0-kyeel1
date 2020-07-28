using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class PizzaOrderJunction2
    {
        public int PizzaOrderjunctionId { get; set; }
        public int PizzaId { get; set; }
        public int OrderId { get; set; }
        public bool Active { get; set; }

        public virtual Order2 Order { get; set; }
        public virtual Pizza2 Pizza { get; set; }
    }
}
