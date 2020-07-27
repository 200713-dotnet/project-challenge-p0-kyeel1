
 
using System;
using System.Collections.Generic;
using PizzaStore.Domain;

namespace PizzaStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name");
            string currentUser = Console.ReadLine();
            var user1 = new User(currentUser);
            var store1 = new Store("pizzahut");
            var Starter = new Starter();
            Order cart = Starter.CreateOrder(user1,store1);
            bool flag = true;
            while(flag){
                flag = newInput(cart);
            }

            bool newInput(Order cart)
            {
             Console.WriteLine("type cheese if you want to add a cheese pizza to the cart");
             Console.WriteLine("type peperoni if you want peperoni");
             Console.WriteLine("type sausage if you want suasage");
             Console.WriteLine("type custom if you want a custom pizza");
             Console.WriteLine("type cart to display the cart");
             Console.WriteLine("type past to display the past orders");
             Console.WriteLine("type total to see your total");
             Console.WriteLine("press enter if you want to exit");
             var temp = new PizzaStore.Client.Starter();
             Pizza tempPizza;
                switch(Console.ReadLine())
                {
                 case "cheese":
                 tempPizza = new Pizza(GetCrust(),GetSize(),new Toppings(new List<string>{"Cheese"}),10.00);
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "pepperoni":
                 tempPizza = new Pizza(GetCrust(),GetSize(),new Toppings(new List<string>{"Pepperoni"}),13.00);
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "suasage": 
                 tempPizza = new Pizza(GetCrust(),GetSize(),new Toppings(new List<string>{"Suasage"}),14.00);
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "custom" :
                 tempPizza = new Pizza(GetCrust(),GetSize(),custom(),16.00);
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "past" :
                 /*var pastCart = SaveManager.Read(currentUser);
                 foreach(Pizza x in pastCart.pizzas){
                     Console.WriteLine($"{x.ToString()}");
                 }
                 */
                 break;

                 case "cart":
                 foreach(Pizza x in cart.pizzas){
                     Console.WriteLine($"{x.ToString()}");
                 }
                 break;

                 case "Total":
                 double tempTotal = 0;
                 foreach(Pizza x in cart.pizzas){
                     tempTotal+= x.Price;
                 }
                 Console.WriteLine($"your total is: {tempTotal}");
                 break;

                 default:
                //SaveManager.Write(cart,currentUser);
                 return false;
                }
             return true;//returns the result of the operation
            
            }
            Toppings custom(){
                bool flag = true;
                List<string> customPizza = new List<string>();
                int customIndex=0;
                while(flag){
                Console.WriteLine("you may only add three toppingsto your pizza");
                Console.WriteLine("type cheese if you want top add a cheese pizza to the cart");
                Console.WriteLine("type peperoni if you want peperoni");
                Console.WriteLine("type sausage if you want suasage");
                Console.WriteLine("press enter if you want to exit");

                switch(Console.ReadLine())
                {
                 case "cheese":
                 customPizza.Add("cheese");
                 break;

                 case "pepperoni" :
                 customPizza.Add("Pepperoni");
                 break;

                 case "suasage": 
                 customPizza.Add("suasage");
                 break;

                 default:
                 flag = false;
                 break;
                }
                if(customIndex ==3)
                 flag = false;
                }
                return new Toppings(customPizza);
            }
            Crust GetCrust()
            {
                Console.WriteLine("type thin if you want a thin crust");
                Console.WriteLine("type thick if you want a thick crust");
                Console.WriteLine("type garlic if you want a garlic crust");
                switch(Console.ReadLine())
                {
                 case "thin":
                 return new Crust("thin");
                 

                 case "thick" :
                 return new Crust("thick");
                 

                 case "garlic": 
                 return new Crust("garlic");
                 
                 default:
                 return GetCrust();
                }
            }
            Size GetSize()
            {
                Console.WriteLine("type small or 12  if you want a small pizza");
                Console.WriteLine("type medium or 14 if you want a medium pizza");
                Console.WriteLine("type large  or 16 if you want a large pizza");
                Console.WriteLine("type 21 or extralarge if you want a large pizza");
                switch(Console.ReadLine())
                {
                 case "small":
                 case "12":
                 return new Size("small");
                 

                 case "medium" :
                 case "14":
                 return new Size("medium");
                 

                 case "large" :
                 case "16":
                 return new Size("large");
                 

                 case "extralarge" :
                 case "21":
                 return new Size("extralarge");
                 

                 default:
                 return GetSize();
                }
            }
        }
    }
}

