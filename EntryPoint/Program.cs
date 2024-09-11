using PointsAndLines;
using EntryPoint.User;
using EntryPoint.StaticInCsharp;
using EntryPoint.ConstantsCsharp;
using EntryPoint.ExceptionHandeling.Service;
using EntryPoint.ExceptionHandeling;
using EntryPoint.ExceptionHandeling.HandelResults;

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

        // Static members are shared between every instance of classes

        Shape triangle = new Shape();
        // Console.WriteLine(Shape.name); // Triangle

        Shape rectangle = new Shape("Rectangle");
        // Console.WriteLine(Shape.name); // Rectangle

        // Console.WriteLine(Shape.numberOfShapes); // 3 (Square, Triangle, Rectangle)

        // Constants in CSharp
        CUsers cu1 = new CUsers();
        CUsers cu2 = new CUsers();
        
        // Console.WriteLine(cu1.id); // 1
        // Console.WriteLine(cu2.id); // 2

        // EXCEPTION HANDELING

        int id = Convert.ToInt32(Console.ReadLine());
        UserService service = new UserService();

        try
        {
            try
            {
                GetCommonUserResult sUser = service.GetUserById(id);
                Console.WriteLine($"Found user: {sUser.User.Name}");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
                throw argEx;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("An unexpected error occured.");
            throw;
        }

        Console.ReadLine();
    }
}