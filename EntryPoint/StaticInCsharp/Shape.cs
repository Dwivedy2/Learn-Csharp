namespace EntryPoint.StaticInCsharp
{
    internal class Shape
    {
        public int width { get; set; }
        public int height { get; set; }
        public static string name = "";
        public static int numberOfShapes = 0;

        public Shape() 
        {
            name = "Triangle";
            numberOfShapes++;
        }
        public Shape(string shape) 
        {
            name = shape;   
            numberOfShapes++;
        }
    }
}
