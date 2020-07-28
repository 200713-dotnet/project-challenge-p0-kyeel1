using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class User2
    {
        public User2()
        {
            OrderJunction2 = new HashSet<OrderJunction2>();
        }

        public int UserId { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<OrderJunction2> OrderJunction2 { get; set; }
    }
}
