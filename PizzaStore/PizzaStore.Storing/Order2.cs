using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Order2
    {
        public int OrderId { get; set; }
        public bool Active { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }
    }
}
