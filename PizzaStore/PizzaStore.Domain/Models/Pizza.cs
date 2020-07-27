using System.Collections.Generic;
namespace PizzaStore.Domain
{
 public class Pizza
 {
  public Size Size {get; }
  public Crust Crust {get; }
  public Toppings Toppings {get;}
  public int Price {get;}

 public Pizza(Crust crust,Size size, Toppings toppings){
   Crust = crust;
   Size = size;
   Toppings = toppings;
   Price = crust.Price + size.Price + toppings.Price;


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