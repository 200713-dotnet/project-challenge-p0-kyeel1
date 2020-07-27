using System.Collections.Generic;
namespace PizzaStore.Domain
{
    public class Order
    {
        public List<Pizza> pizzas = new List<Pizza>();

        public void createPizza(Crust crust, Size size, Toppings toppings,double price){
            pizzas.Add(new Pizza(crust,size,toppings,price));
        }
        public override string ToString()
        {
            string result= "";
            foreach(Pizza x in pizzas)
            result+=$"{x.ToString()},";
            return result;
        }
    }
}