using System.Collections.Generic;

namespace PizzaStore.Domain
{
    public class Toppings
    {
        public List<string> Content{get;}

        public Toppings()
        {
            Content = new List<string>();
        }
        public void addTopping(string topping)
        {
            Content.Add(topping);
        }
        public override string ToString()
        {
            string result = "";
            foreach(string x in Content)
                result += $"{x},";
            return result;
        } 
    }
}