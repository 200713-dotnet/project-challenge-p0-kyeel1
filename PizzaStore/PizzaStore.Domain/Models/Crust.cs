namespace PizzaStore.Domain
{
    public class Crust
    {
        
        public string Name{get;}
        public string Description {get;}

        public Crust(string name)
        {
            Name = name;
        }
        public Crust(){}
        public override string ToString()
        {
            return $"the crust is called {Name} {Description}";
        } 
    }
}