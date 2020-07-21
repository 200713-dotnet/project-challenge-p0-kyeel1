namespace PizzaStore.Domain
{
    public class Name
    {
        public string name {get;}
        public Name(string x)
        {
            name = x;
        }
        public override string ToString()
        {
            return name;
        }

    }
}