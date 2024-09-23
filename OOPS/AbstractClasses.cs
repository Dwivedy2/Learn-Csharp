namespace OOPS
{
    internal class AbstractClasses
    {
        public static void Start()
        {
            // Problem: Here xml and json classes are implementing the same code for Write method
            // when inherited from interface.

            XML xML = new XML();
            xML.Write("some random text");

            Json json = new Json();
            json.Write("some random text");

            // Solution: Implement the interface to a base class and then inherit the base class
            // But ??

            // But you have to initialise the base class
            UpgradedXml upgradedXml = new UpgradedXml("Hello, see need to initialise the base class");
            upgradedXml.Write1();

            // But this is not good to only have a function and we need to initialise an instance to carry that
            // So we use abstract classes instead

            // AbstracXml xml = new AbstracXml(); // not allowed
            DemoXml demoXml = new DemoXml();
            demoXml.Write("Hello, see need to override the Write method");

            // Other than abstract class I have sealed class also
            // whose methods cannot be inherited
        }
    }

    interface IWrite
    {
        void Write(string value);
    }

    class XML : IWrite
    {
        public void Write(string value)
        {
            Console.WriteLine($"{value} in xml");
        }
    }

    class Json : IWrite
    {
        public void Write(string value)
        {
            Console.WriteLine($"{value} in json");
        }
    }

    interface IWrite1
    {
        void Write1();
    }

    class BaseClass : IWrite1
    {
        string _value = "";

        public BaseClass(string val)
        {
            _value = val;
        }

        public void Write1()
        {
            Console.WriteLine($"'{this._value}' is added in Some randome text");
        }
    }

    class UpgradedXml : BaseClass
    {
        public UpgradedXml(string val) : base(val)
        {
        }
    }

    class UpgradedJson : BaseClass
    {
        public UpgradedJson(string val) : base(val)
        {

        }
    }

    abstract class AbstracXml 
    {
        // you may put abstract or not, but if method is abstract then
        // class is a must have abstract
        public abstract void Write(string value);
    }

    class DemoXml : AbstracXml
    {
        // so need to put override when implementing abstract classes
        public override void Write(string value)
        {
            Console.WriteLine("DemoXml used override to implement the abstract classes");
        }
    }
    
    sealed class CannotBeInherited
    {

    }


    // not allowed
    //class DemoSealed : CannotBeInherited
    //{

    //}
}
