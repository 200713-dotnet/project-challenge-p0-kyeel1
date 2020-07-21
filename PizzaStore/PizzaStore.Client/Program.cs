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
            var name = new Name(currentUser);
            var user1 = new User(name);
            var store1 = new Store("PizzaStore","a modest pizza store in downtown Fargo");
            var Starter = new Starter();
            Order cart = Starter.CreateOrder(user1,store1);
            bool flag = true;
            while(flag){
                flag = newInput();
            }
            bool newInput()
            {
             Console.WriteLine("type cheese if you want top add a cheese pizza to the cart");
             Console.WriteLine("type peperoni if you want peperoni");
             Console.WriteLine("type sausage if you want suasage");
             Console.WriteLine("type custom if you want a custom pizza");
             Console.WriteLine("type cart to display the cart");
             Console.WriteLine("type past to display the past orders");
             Console.WriteLine("type total to see your total");
             Console.WriteLine("press enter if you want to exit");
             var temp = new PizzaStore.Client.Starter();
                switch(Console.ReadLine())
                {
                 case "cheese":
                 DefaultPizza("cheese");
                 break;

                 case "pepperoni" :
                 DefaultPizza("pepperoni");
                 break;

                 case "suasage": 
                 DefaultPizza("suasage");
                 break;

                 case "custom" :
                 Custom();
                 break;
                /*
                 case "past" :
                 var pastCart = SaveManager.Read(currentUser);
                 foreach(Pizza x in pastCart.pizzas){
                     Console.WriteLine($"{x.ToString()}");
                 }
                 break;
                */
                 case "cart":
                 foreach(Pizza x in cart.pizzas){
                     Console.WriteLine($"{x.ToString()}");
                 }
                 break;

                 case "Total":
                 double tempTotal = 0;
                 foreach(Pizza x in cart.pizzas){
                     tempTotal+= x.Cost;
                 }
                 Console.WriteLine($"your total is: {tempTotal}");
                 break;

                 default://make it post to sql server here
                 return false;
                }
             return true;//returns the result of the operation
            
            }

            void Custom(){
                bool flag = true;
                Toppings toppings = new Toppings();
                int[] tFlag = {0,0,0};

                while(flag){
                Console.WriteLine("type cheese if you want top add extra cheese");
                Console.WriteLine("type peperoni if you want peperoni");
                Console.WriteLine("type sausage if you want suasage");
                Console.WriteLine("press enter if you want to exit");

                switch(Console.ReadLine())
                {
                 case "cheese":
                 if(tFlag[0]<2){
                 toppings.addTopping("Cheese");
                 }
                 else
                 Console.WriteLine("cant add any more cheese");
                 break;

                 case "pepperoni" :
                 if(tFlag[1]<2){
                 toppings.addTopping("Pepperoni");
                 tFlag[1]+= 1;
                 }
                 else
                 Console.WriteLine("cant add any more pepperoni");
                 break;

                 case "suasage": 
                 if(tFlag[2]<2){
                 toppings.addTopping("Suasage");
                 tFlag[2]+= 1;
                 }
                 else
                 Console.WriteLine("cant add any more suasage");
                 break;

                 default:
                 flag = false;
                 break;
                }

                cart.createPizza(WhatCrust(),WhatSize(),toppings);
            }
            }

            void DefaultPizza(string type)
            {
                
                Toppings toppings = new Toppings();
                
                switch(type)
                {
                    case "cheese":
                    toppings.addTopping("cheese");
                    break;

                    case "pepperoni":
                    toppings.addTopping("cheese");
                    toppings.addTopping("pepperoni");
                    break;

                    case "sausuage":
                    toppings.addTopping("cheese");
                    toppings.addTopping("suasage");
                    break;
                }

                cart.createPizza(WhatCrust(),WhatSize(),toppings);

            }
            Size WhatSize()
            {
                Console.WriteLine("what size do you want this pizza: /n Small,Medium,Large,Extra-Large");
                var input = Console.ReadLine();
                return new Size(input);
            }
            Crust WhatCrust()
            {
                Console.WriteLine("what crust do you want on the pizza: /n thick,thin,garlic");
                var input = Console.ReadLine();
                switch(input)
                {
                    case "thick":
                    return new Crust("Thick","a thicker crust");

                    case "thin":
                    return new Crust("Thin","a thinner crust");

                    case "garlic":
                    return new Crust("Garlic","a crust made with garlic");

                    default:
                    return new Crust();
                }
            }
        }
    }
}
