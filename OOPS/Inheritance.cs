namespace OOPS
{
    public class Inheritance
    {
        public static void Start()
        {
            // Write class object
            Write writter = new Write("Marksheet.pdf");

            writter.Format();

            // XML class object
            XMLFormatter xmlFormatter = new XMLFormatter("SportsKit.doc");

            xmlFormatter.Format();

            // JSON class object
            JSONFormatter jsonFormatter = new JSONFormatter("ToolKit.xlx");

            jsonFormatter.Format();

            // Assigning the objects of child class to parent
            writter = new XMLFormatter("demo.txt"); // allowed

            // XMLFormatter x1 = new Write("demo.txt"); // not allowed
            
            // Although the parent object can point to child object
            // but the parent object can only access its class methods
            // and not the child methods.

            // writter.ShowFile(); // not allowed

        }
    }

    public class Write
    {
        public string? FileName { get; set; }

        public Write(string? FileName)
        {
            this.FileName = FileName;
        }

        public virtual void Format()
        {
            try
            {
                if (this.FileName.Contains('.'))
                {
                    int index = this.FileName.IndexOf('.');
                    string format = this.FileName.Substring(index + 1);
                    Console.WriteLine($"file {this.FileName} is written in {format} format.");
                }
                else
                {
                    Console.WriteLine("Could not found the format of the file");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("File should have a name");
            }
        }
    }

    public class XMLFormatter : Write
    {
        // Calling of constructor of the parent 'Write' Class
        // Passing argument 'filename' to provide value of FileName
        public XMLFormatter(string filename) : base(filename)
        {

        }

        // It will give warning, as without the new keyword the Format() function of 
        // parent class is hidden, so to prevent that use the new keyword.
        public new void Format()
        {
            Console.WriteLine($"file {this.FileName} is written to XML format");
        }

        // A function of XMLFormatter class
        public void ShowFile()
        {
            Console.WriteLine("filename: " + this.FileName);
        }
    }

    public class JSONFormatter : Write
    {
        public JSONFormatter(string filename) : base(filename)
        {

        }

        // Overriding Format function of the Write class as to give it 
        // some custom implementation
        public override void Format()
        {
            Console.WriteLine($"file {this.FileName} is formatted to JSON format");
        }
    }
}
