namespace OOPS
{
    public class AnonymousObjectsAndNullable
    {
        public static void Start()
        {
            // Anonymous Classes

            var someObjWhoseClassIsNotKnown = new { name = "Omkareshwar Nath Dwivedy", age = 24 };

            // int x = null; // not allowed

            int? x = null;

            if (x.HasValue)
            {
                Console.WriteLine($"X: {x}");
            }
            else
            {
                Console.WriteLine("x is null");
            }
        }
    }
}
