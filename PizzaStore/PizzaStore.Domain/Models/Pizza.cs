using System.Collections.Generic;
namespace PizzaStore.Domain
{
 public class Pizza
 {
  public Size Size {get; }
  public Crust Crust {get; }
  public Toppings Toppings {get;}
  public double Price {get;}

 public Pizza(Crust crust,Size size, Toppings toppings,double price){
   Crust = crust;
   Size = size;
   Toppings = toppings;
   Price = price;


 }
 public override string ToString()
 {
  return $"size:{Size} crust:{Crust} toppings: {Toppings} price: {Price}";
 }
public Pizza()
{

}
}
}