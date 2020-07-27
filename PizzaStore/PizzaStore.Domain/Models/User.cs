using System.Collections.Generic;
namespace PizzaStore.Domain
{
    public class User
    {
        public string Name{get;set;}
        public List<Order> orders{get;}
        public User(string name)
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