namespace EntryPoint.StaticClasses
{
    public static class Utilities
    {
        // static classes dont have constructors, as not possible like
        // Utitlities ut = new Utitlities

        /*
        public Utilities()
        {
            
        }
        */

        // methods inside static classes are static, as normal methods requires objects to be accessed
        public static void ColorfulWriteLine(string message, dynamic color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
