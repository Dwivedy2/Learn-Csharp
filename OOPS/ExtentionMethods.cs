namespace OOPS
{
    // Static class is neccessary for defining a Extention Method,
    // without static keyword it will give error.
    public static class ExtentionMethods
    {
        public static void Start()
        {
            int n = -12345,
                count;

            // Without Extention Method
            count = DigitCount(n);

            // With Extention Method, its like adding a new function to int type
            count = n.DigitCountEx();

            Console.WriteLine(count);
        }
        public static int DigitCount(int n)
        {
            int count = 0;
            n = Math.Abs(n);
            while (n > 0)
            {
                count++;
                n /= 10;
            }
            return count;
        }

        public static int DigitCountEx(this int n)
        {
            return DigitCount(n);
        }
    }
}
