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
                return "Small";
                
                case 14:
                Price = 12;
                return "Medium";

                case 16:
                Price = 14;
                return "Large";

                case 21:
                Price = 16;
                return "Extra-Large";

                default:
                return "";
            }
        }
        public int GetDiameter(string x)
        {
            switch(x)
            {
                case "Small":
                return 12;
                
                case "Medium":
                return 14;

                case "Large":
                return 16;

                case "Extra-Large":
                return 21;

                default:
                return 0;
            }
        }

        public override string ToString()
        {
            return $"a {size} {Diameter}\" Pizza";
        }
    }
}