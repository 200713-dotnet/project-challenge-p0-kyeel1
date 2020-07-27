namespace PizzaStore.Domain
{
    public class Crust
    {
        
        public string Name{get;}
        public string Description {get;}
        public int Price{get;}

        public Crust(string name,int price)
        {
            Name = name;
            Price = price;
        }
        public Crust(){}
        public override string ToString()
        {
            return $"the crust is called {Name} {Description}";
        } 
    }
}