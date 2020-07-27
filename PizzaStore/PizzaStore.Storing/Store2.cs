using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Store2
    {
        public int StoreId { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateModified { get; set; }
    }
}
