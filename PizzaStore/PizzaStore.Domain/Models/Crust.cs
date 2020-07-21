namespace PizzaStore.Domain
{
    public class Crust
    {
        
        public string Name{get;}
        public string Description {get;}

        public Crust(string name,string description)
        {
            Name = name;
            Description = description;
        }
        public Crust(){}
        public override string ToString()
        {
            return $"the crust is called {Name} {Description}";
        } 
    }
}