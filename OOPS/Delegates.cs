namespace OOPS
{
    internal class Delegates
    {
        // Delegate
        public delegate void WriteDelegate(string txt);

        public static void Start()
        {
            // Delegates are reference to the methods.

            WriteDelegate writeDelegate = new WriteDelegate(Write);

            if (true)
            {
                Demo(writeDelegate);
            }

            // Types of Delegates
            // Returnable 
            // Func<T, T, ReturnType> where T is params

            // Non Returnable
            // Action<T, T>

            // Example
            Func<string, int> textLengthRef = new Func<string, int>(TextLength);

            // Or
            Func<string, int> textLengthDel = TextLength;

            int length = textLengthDel("Whatismylength");

            Console.WriteLine("Length: " + length);

            Action<string> writeRef = new Action<string>(Write);

            // Or
            Action<string> writeDel = Write;
            writeDel("Anything");

        }

        public static void Demo(WriteDelegate writeReference)
        {
            writeReference("Executing through delegates");
        }


        public static void Write(string txt)
        {
            Console.WriteLine($"Text: '{txt}'");
        }

        public static int TextLength(string txt)
        {
            return txt.Length;
        }
    }
}
