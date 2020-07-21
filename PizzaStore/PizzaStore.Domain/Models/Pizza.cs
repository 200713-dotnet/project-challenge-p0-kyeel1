using System.Collections.Generic;
namespace PizzaStore.Domain
{
 public class Pizza
 {
  public Size Size {get; }
  public Crust Crust {get; }
  public Toppings Toppings {get;}

  public double Cost {get; }
 public Pizza(Crust crust,Size size, Toppings toppings){
   Crust = crust;
   Size = size;
   Toppings = toppings;


 }
 public override string ToString()
 {
  return $"size:{Size} crust:{Crust} toppings: {Toppings} cost: {Cost}";
 }
public Pizza()
{

}
}
}