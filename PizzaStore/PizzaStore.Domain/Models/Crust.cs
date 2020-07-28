namespace PizzaStore.Domain
{
    public class Crust
    {
        
        public string Name{get;}
        public string Description {get;}
        public int Price{get;}

        public Crust(string name)
        {
            Name = name;
            Price = CalculatePrice(name);
        }
        public Crust(){}
        public override string ToString()
        {
            return $"the crust is called {Name} {Description}";
        } 
        public int CalculatePrice(string name)
        {
            switch(name)
            {
                case "thin":
                return 1;

                case "thick":
                return 2;

                default:
                return 3; 
            }
        }
    }
}