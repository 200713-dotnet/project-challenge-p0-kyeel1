using System.Collections.Generic;
namespace PizzaStore.Domain
{
    public class User
    {
        public Name Name{get;}
        public List<Order> orders{get;}
        public User(Name name)
        {
            Name = name;
            orders = new List<Order>();
        }
        public override string ToString()
        {
            string result = $"the user is: {Name}";
            return result;
        } 
    }
    
}