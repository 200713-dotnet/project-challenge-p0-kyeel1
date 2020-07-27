using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class OrderJunction2
    {
        public int OrderJunctionId { get; set; }
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public int? StoreId { get; set; }
        public bool Active { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }
    }
}
