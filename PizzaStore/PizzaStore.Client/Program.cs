
using System.Linq;
using System;
using System.Collections.Generic;
using PizzaStore.Domain;
using PizzaStore.Storing;
using DB = PizzaStore.Storing;
using CL = PizzaStore.Domain;
namespace PizzaStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PIZZASTORE2Context dbo = new PIZZASTORE2Context();
            List<CL.Store> availableStores = new List<CL.Store>();
            {
                foreach(var s in dbo.Store2.ToList())
                {
                    var tempStore = new CL.Store(s.Name);
                    foreach(var oj in dbo.OrderJunction2)
                        if(oj.StoreId == s.StoreId){
                        var tempID = oj.OrderId;
                        }
                        foreach(var o in dbo.Order2){
                            //if(tempID == o.OrderId){
                                var tempOrder = new CL.Order();
                                //foreach(var pj in dbo.)
                                //tempOrder.pizzas = o
                                //tempStore.orders.Add(o);
                            }
                        }
                
            }  
            if(ModeSwitch() == "store"){
                Console.WriteLine("selct your store");

            }
            else{
            Console.WriteLine("Please enter username");
            string currentUsername = Console.ReadLine();
            var user1 = new PizzaStore.Domain.User(currentUsername);
            var store1 = new PizzaStore.Domain.Store("pizzahut");
            var Starter = new Starter();
            PizzaStore.Domain.Order cart = Starter.CreateOrder(user1,store1);
            
            bool flag = true;
            while(flag){
                flag = newInput(cart,currentUsername);
            }
            }
            bool newInput(PizzaStore.Domain.Order cart,string currentUsername)
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
                 tempPizza = new Pizza(GetCrust(),GetSize(),new PizzaStore.Domain.Toppings(new List<string>{"Cheese"}),10.00);
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "pepperoni":
                 tempPizza = new Pizza(GetCrust(),GetSize(),new PizzaStore.Domain.Toppings(new List<string>{"Pepperoni"}),13.00);
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "suasage": 
                 tempPizza = new Pizza(GetCrust(),GetSize(),new PizzaStore.Domain.Toppings(new List<string>{"Suasage"}),14.00);
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
                 
                    DB.User2 dbUser = new DB.User2();
                    DB.Store2 dbStore = new DB.Store2();
                    {
                        var index = 0;
                        foreach(var p in dbo.User2.ToList())
                        {
                            var tempName = p.Name;
                            index += 1;
                            if(tempName == currentUsername)
                            {
                                dbUser = p;
                            }
                        }
                        dbUser.Name = currentUsername;
                        dbUser.UserId = index+1;
                        dbo.Add(dbUser);

                        
                    }
                    
                    
                    
                        
                    
                    
                    DB.Order2 dbCart = new DB.Order2();
                    
                    


                 return false;
                }
             return true;//returns the result of the operation
            
            }
            PizzaStore.Domain.Toppings custom(){
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
                return new PizzaStore.Domain.Toppings(customPizza);
            }
            PizzaStore.Domain.Crust GetCrust()
            {
                Console.WriteLine("type thin if you want a thin crust");
                Console.WriteLine("type thick if you want a thick crust");
                Console.WriteLine("type garlic if you want a garlic crust");
                switch(Console.ReadLine())
                {
                 case "thin":
                 return new PizzaStore.Domain.Crust("thin");
                 

                 case "thick" :
                 return new PizzaStore.Domain.Crust("thick");
                 

                 case "garlic": 
                 return new PizzaStore.Domain.Crust("garlic");
                 
                 default:
                 return GetCrust();
                }
            }
            PizzaStore.Domain.Size GetSize()
            {
                Console.WriteLine("type small or 12  if you want a small pizza");
                Console.WriteLine("type medium or 14 if you want a medium pizza");
                Console.WriteLine("type large  or 16 if you want a large pizza");
                Console.WriteLine("type 21 or extralarge if you want a large pizza");
                switch(Console.ReadLine())
                {
                 case "small":
                 case "12":
                 return new PizzaStore.Domain.Size("small");
                 

                 case "medium" :
                 case "14":
                 return new PizzaStore.Domain.Size("medium");
                 

                 case "large" :
                 case "16":
                 return new PizzaStore.Domain.Size("large");
                 

                 case "extralarge" :
                 case "21":
                 return new PizzaStore.Domain.Size("extralarge");
                 

                 default:
                 return GetSize();
                }
            }
             string ModeSwitch()
            {
                Console.WriteLine("please enter store if yyou wish to continue as as store or user to continue as a user");
                switch(Console.ReadLine())
                {
                    case"store":
                    return "store";

                    case"user":
                    return"user";

                    default:
                    return ModeSwitch();

                }
            }
        }
    }
}

