using System.Collections.Generic;
namespace PizzaStore.Domain
{
    public class Store
    {
        public string Name{get;}
        public List<Order> orders{get;}
        
        public string Description{get;}
        public Store(string description,string name){
            orders = new List<Order>();
            Description = description;
            Name = name;
        }
        public Order CreateOrder()
        {
            return new Order();
        }
        public override string ToString()
        {
            string result = $"{Name} {Description}";
            return result;
        } 

    }
}