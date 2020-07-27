
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
            CL.Store currentStore= new CL.Store("temp");
            List<CL.Store> availableStores = new List<CL.Store>();
            {
                foreach(var s in dbo.Store2.ToList())
                {
                    var tempStore = new CL.Store(s.Name);
                    foreach(var oj in dbo.OrderJunction2){
                        if(oj.StoreId == s.StoreId){
                        var tempID = oj.OrderId;
                        }
                        foreach(var o in dbo.Order2){
                            //if(tempID == o.OrderId){
                                var tempOrder = new CL.Order();
                                /*
                                //foreach(var poj in dbo.PizzaOrderJunction2.ToList()){
                                if(tempID == poj.OrderId){
                                    List<string> toppings = new List<string>();
                                    foreach(var pj in dbo.PizzaJunction2.ToList()){
                                        if(pj.PizzaID == poj.PizzaID){
                                            toppings.add(pj.Name);
                                        }
                                    
                                    }
                                    var tempPizza = new Pizza(toppings);
                                    tempOrder.orders.add(tempPizza);
                                }

                                }
                                //tempStore.orders.Add(o);
                                */
                            }
                        }
                    availableStores.Add(tempStore);
                    }

                
            }  
            if(ModeSwitch() == "store"){
                
                var flag = true;
                Console.WriteLine("selct your store");
                var inputName =Console.ReadLine();
                foreach(CL.Store a in availableStores)
                {
                    if(a.Name == inputName){
                        currentStore = a;
                        flag = false;
                    }
                }
                if(flag)
                {
                    currentStore = new CL.Store(inputName);
                }
                Console.WriteLine("type sales to see sales");
                Console.WriteLine("type orders to see orders");
                switch(Console.ReadLine()){
                
                
                }

            

            }

            else{

            Console.WriteLine("Please enter username");
            string currentUsername = Console.ReadLine();
            var currentUser = new PizzaStore.Domain.User(currentUsername);
            Console.WriteLine("please select a pizza store");
            foreach(var s in availableStores){
                Console.WriteLine($"type {s.Name} to select {s.Name} as the resteraunt you want to go to.");
            }
            var currentStoreName = Console.ReadLine();
            currentStore = new CL.Store(currentStoreName);
            foreach(var s in availableStores){
                if(s.Name == currentStoreName){
                    currentStore = s;
                }
            }
            
            foreach(var u in dbo.User2.ToList()){
                if(u.Name == currentUsername){
                    currentUser.Name = currentUsername;
                    foreach(var oj in dbo.OrderJunction2){
                        if(oj.UserId == u.UserId){
                        var tempID = oj.OrderId;
                        }
                        foreach(var o in dbo.Order2){
                            //if(tempID == o.OrderId){
                                var tempOrder = new CL.Order();
                                /*
                                //foreach(var poj in dbo.PizzaOrderJunction2.ToList()){
                                if(tempID == poj.OrderId){
                                    List<string> toppings = new List<string>();
                                    foreach(var pj in dbo.PizzaJunction2.ToList()){
                                        if(pj.PizzaID == poj.PizzaID){
                                            toppings.add(pj.Name);
                                        }
                                    
                                    }
                                    var tempPizza = new Pizza(toppings);
                                    tempOrder.orders.add(tempPizza);
                                }

                                }
                                currentUser.orders.Add(o);
                                */
                            }
                        }
                }
            }
            
            
            var Starter = new Starter();
            PizzaStore.Domain.Order cart = Starter.CreateOrder(currentUser,currentStore);
            
            bool flag = true;
            while(flag){
                flag = newInput(cart,currentUser);
            }
            }
            bool newInput(CL.Order cart,CL.User currentUser)
            {
             Console.WriteLine("type cheese if you want to add a cheese pizza to the cart");
             Console.WriteLine("type peperoni if you want peperoni");
             Console.WriteLine("type sausage if you want suasage");
             Console.WriteLine("type custom if you want a custom pizza");
             Console.WriteLine("type cart to display the cart");
             Console.WriteLine("type past to display the past orders");
             Console.WriteLine("type total to see your total");
             Console.WriteLine("type delete to delete a pizza");
             Console.WriteLine("press enter if you want to exit");
             var temp = new PizzaStore.Client.Starter();
             Pizza tempPizza;
                switch(Console.ReadLine())
                {
                 case "cheese":
                 tempPizza = new Pizza(GetCrust(),GetSize(),new PizzaStore.Domain.Toppings(new List<string>{"Cheese"},1));
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "pepperoni":
                 tempPizza = new Pizza(GetCrust(),GetSize(),new PizzaStore.Domain.Toppings(new List<string>{"Pepperoni"},1));
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "suasage": 
                 tempPizza = new Pizza(GetCrust(),GetSize(),new PizzaStore.Domain.Toppings(new List<string>{"Suasage"},1));
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "custom" :
                 tempPizza = new Pizza(GetCrust(),GetSize(),custom());
                 cart.pizzas.Add(tempPizza);
                 break;

                 case "past" :
                 var pastCart = currentUser;
                 foreach(CL.Order O in pastCart.orders){
                     foreach(CL.Pizza p in O.pizzas)
                     Console.WriteLine($"{p.ToString()}");
                 }
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
                
                 case "delete":
                 deletePizza(cart);
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
                            if(tempName == currentUser.Name)
                            {
                                dbUser = p;
                            }
                        }
                        dbUser.Name = currentUser.Name;
                        dbUser.UserId = index+1;
                        dbo.Add(dbUser);

                        
                    }

                    DB.Order2 dbCart = new DB.Order2();
                 return false;
                }
             return true;//returns the result of the operation
            
            }
            CL.Toppings custom(){
                bool flag = true;
                List<string> customPizza = new List<string>();
                int customIndex=0;
                while(flag){
                Console.WriteLine("you may only add four toppingsto your pizza");
                Console.WriteLine("type cheese if you want top add a cheese pizza to the cart");
                Console.WriteLine("type peperoni if you want peperoni");
                Console.WriteLine("type sausage if you want suasage");
                Console.WriteLine("press enter if you want to exit");

                switch(Console.ReadLine())
                {
                 case "cheese":
                 customPizza.Add("cheese");
                 customIndex+=1;
                 break;

                 case "pepperoni" :
                 customPizza.Add("Pepperoni");
                 customIndex+=1;
                 break;

                 case "suasage": 
                 customPizza.Add("suasage");
                 customIndex+=1;
                 break;

                 default:
                 flag = false;
                 break;
                }
                if(customIndex ==4)
                 flag = false;
                }
                return new PizzaStore.Domain.Toppings(customPizza,2);
            }
            PizzaStore.Domain.Crust GetCrust()
            {
                Console.WriteLine("type thin if you want a thin crust");
                Console.WriteLine("type thick if you want a thick crust");
                Console.WriteLine("type garlic if you want a garlic crust");
                switch(Console.ReadLine())
                {
                 case "thin":
                 return new CL.Crust("thin",1);
                 

                 case "thick" :
                 return new CL.Crust("thick",2);
                 

                 case "garlic": 
                 return new CL.Crust("garlic",3);
                 
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
                 return new CL.Size("small");
                 

                 case "medium" :
                 case "14":
                 return new CL.Size("medium");
                 

                 case "large" :
                 case "16":
                 return new CL.Size("large");
                 

                 case "extralarge" :
                 case "21":
                 return new CL.Size("extralarge");
                 

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
            void deletePizza(CL.Order cart)
            {
                
                foreach(Pizza p in cart.pizzas)
                {
                    Console.WriteLine($" {p.ToString()}");
                    Console.WriteLine("delete this pizza(y/n)?");
                    if(Console.ReadLine() == "y"){
                        cart.pizzas.Remove(p);
                    }

                }
                
                
            }
        }
    }
}

