using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Order2
    {
        public Order2()
        {
            OrderJunction2 = new HashSet<OrderJunction2>();
            PizzaOrderJunction2 = new HashSet<PizzaOrderJunction2>();
        }

        public int OrderId { get; set; }
        public bool Active { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<OrderJunction2> OrderJunction2 { get; set; }
        public virtual ICollection<PizzaOrderJunction2> PizzaOrderJunction2 { get; set; }
    }
}
