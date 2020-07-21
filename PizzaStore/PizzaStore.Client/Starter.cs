using System.Collections.Generic;
using PizzaStore.Domain;
namespace PizzaStore.Client
{
 public class Starter
 {
  public Order CreateOrder(User user,Store store)
  {
      var order = new Order();
      user.orders.Add(order);
      store.orders.Add(order);
      return order;

  }
 }
}
