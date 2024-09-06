namespace EntryPoint.StaticInCsharp
{
    internal class Shape
    {
        public int width { get; set; }
        public int height { get; set; }
        public static string name = "";

        public Shape() 
        {
            name = "Triangle";
        }
        public Shape(string shape) 
        {
            name = shape;   
        }
    }
}
