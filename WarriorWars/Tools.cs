namespace WarriorWars
{
    public static class Tools
    {
        public static void ColourfulWriteLine(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg); 
            Console.ResetColor();
        }
    }
}
