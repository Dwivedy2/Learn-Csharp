namespace OOPS
{
    internal class Interfaces
    {
        public static void Start()
        {
            // What is Interface: Contract between a class that it should 
            // implement all the function in interface when inheriting it.

            // Example
            Writer writer = new Writer();
            writer.GetFormat();
            writer.Write("Hello Interfaces");

            // Since interface is a parent which is inherited by child classes
            // so it can point to the objects of child classes

            // Example
            IWriter iwriter = new Writer(); // allowed
            iwriter.Write("iwriter has only access to the methods, which are defined in IWriter interface");
            // iwriter.GetFormat(); // not allowed

            // Decoupling (Tight Coupling): Interfaces solves a major problem of dependency of classes
            // as if class A is dependent on class B and any changes in class B is done then needs to be done in class A
            // also if class C wants to be dependent on B then a new set of dependency needs to be created as 
            // functions that are ment to accept objects of class A do not accept objects of class c

            // Example
            AWrite aWrite = new AWrite();
            XmlWrite xml = new XmlWrite(aWrite);

            // Solution of Decoupling: Use interface as first as anything changes in interface then its mandatory
            // to implement it and same interface objects can be passed between classes those implemented it.

            // Example

            // This is called Dependency Injection
            XmlWrite xml2 = new XmlWrite(new AWrite());

            JsonWrite jsonWrite = new JsonWrite(new AWrite());
        }
    }

    // Interface Syntax
    interface IWriter
    {
        void Write(string value);
    }

    class Writer : IWriter
    {
        // Implemented IWriter method
        public void Write(string value)
        {
            Console.WriteLine($"The '{value}' is written in file");
        }

        public void GetFormat()
        {
            Console.WriteLine("Format: txt");
        }
    }

    interface IAWrite
    {
        void WriteInFile();
    }

    class AWrite : IAWrite 
    {
        public void WriteInFile()
        {
            Console.WriteLine("Written in file");
        }
    }

    class XmlWrite 
    {
        // Dependency Injection via constructor
        private readonly IAWrite _aWrite;

        public XmlWrite(IAWrite aWrite)
        {
            _aWrite = aWrite;
        }

        public void xml()
        {
            Console.WriteLine("xml format.");
        }
    }

    class JsonWrite
    {
        // Dependency Injection via constructor
        private readonly IAWrite _aWrite;

        public JsonWrite(AWrite aWrite)
        {
            _aWrite = aWrite;
        }

        public void json()
        {
            Console.WriteLine("json format.");
        }
    }
}
