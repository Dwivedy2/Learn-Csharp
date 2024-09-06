using PointsAndLines;
using EntryPoint.User;
using EntryPoint.StaticInCsharp;
using System;
class Practice
{
    static void Main()
    {
        Point p = new Point(5, 9);

        Point p2 = new Point();
        p2.X = 34444;
        p2.Y = 66333;

        User user = new User();
        user.Username = "user";
        user.Password = "pass";

        Shape shape = new Shape();
        shape.width = 5;
        shape.height = 5;
        // shape.name = "rectangle"; // not allowed
        Shape.name = "Square";
        
        Console.ReadLine();
    }
}