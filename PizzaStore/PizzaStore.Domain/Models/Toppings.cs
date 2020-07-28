using System.Collections.Generic;

namespace PizzaStore.Domain
{
    public class Toppings
    {
        public List<string> Content{get;}
        public int Price{get; set;}
        public Toppings()
        {
            Content = new List<string>();
            Price = 0;
        }
        public Toppings(List<string> x)
        {
            Content = x;
            Price = CalculatePrice(x);
        }
        public void addTopping(string topping)
        {
            Content.Add(topping);
            Price += 1;
        }
        public int CalculatePrice(List<string> content)
        {
            switch(content.Count)
            {
                case 1:
                return 1;

                case 2:
                return 2;

                default:
                return 3; 
            }
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