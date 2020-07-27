using System.Collections.Generic;

namespace PizzaStore.Domain
{
    public class Toppings
    {
        public List<string> Content{get;}
        public int Price{get;}
        public Toppings(int price)
        {
            Content = new List<string>();
            Price = price;
        }
        public Toppings(List<string> x,int price)
        {
            Content = x;
            Price = price;
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