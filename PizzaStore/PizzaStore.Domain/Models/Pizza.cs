using System.Collections.Generic;
namespace PizzaStore.Domain
{
 public class Pizza
 {
  public Size Size {get; }
  public Crust Crust {get; }
  public Toppings Toppings {get;}
  public int Price {get;}
  public string Name {get;}
 public Pizza(Crust crust,Size size, Toppings toppings,string name){
   Crust = crust;
   Size = size;
   Toppings = toppings;
   Price = crust.Price + size.Price + toppings.Price;
   Name = name;


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