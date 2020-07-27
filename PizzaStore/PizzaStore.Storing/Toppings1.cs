using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Toppings1
    {
        public int ToppingsId { get; set; }
        public bool? Active { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }
    }
}
