using PointsAndLines;
using EntryPoint.User;
using System;
class Practice
{
    static void Main()
    {
        Point p = new Point(5, 9);

        Point p2 = new Point();
        p2.X = 34444;
        p2.Y = 66333;

        //Console.WriteLine(p.X);
        //Console.WriteLine(p.Y);

        //Console.WriteLine(p2.X + ", " + p2.Y);

        User user = new User();
        user.Username = "user";
        user.Password = "pass";

        Console.WriteLine($"Username: {user.Username}\nPassword: {user.Password}");
        Console.ReadLine();
    }
}