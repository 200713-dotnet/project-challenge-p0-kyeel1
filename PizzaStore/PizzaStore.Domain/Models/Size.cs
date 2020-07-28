namespace PizzaStore.Domain
{
    public class Size
    {
        public int Diameter{get;}
        public string size{get;}
        public int Price{get;set;}
        public Size(int diameter,string x)
        {
            Diameter = diameter;
            size = x;
        }
        public Size(int diameter)
        {
            Diameter = diameter;
            size = GetSize(diameter);
        }
        public Size(string x)
        {
            size = x;
            Diameter = GetDiameter(x);
            
        }
        public string GetSize(int diameter)
        {
            switch(diameter)
            {
                case 12:
                Price = 10;
                return "small";
                
                case 14:
                Price = 12;
                return "medium";

                case 16:
                Price = 14;
                return "large";

                case 21:
                Price = 16;
                return "extralarge";

                default:
                return "";
            }
        }
        public int GetDiameter(string x)
        {
            switch(x)
            {
                case "small":
                Price = 10;
                return 12;
                
                case "medium":
                Price = 12;
                return 14;

                case "large":
                Price = 14;
                return 16;

                case "extralarge":
                Price= 16;
                return 21;

                default:
                Price = 10;
                return 0;
            }
        }

        public override string ToString()
        {
            return $"a {size} {Diameter}\" Pizza";
        }
    }
}