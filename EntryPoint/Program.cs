using PointsAndLines;
using System;
class EntryPoint
{
    static void Main()
    {
        Point p = new Point(5, 9);

        Point p2 = new Point();
        p2.x = 3;
        p2.y = 66;

        Console.WriteLine(p.x);
        Console.WriteLine(p.y);

        Console.WriteLine(p2.x + ", " + p2.y);
        Console.ReadLine();
    }
}