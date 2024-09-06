namespace PointsAndLines
{
    public class Point
    {
        private int x;
        private int y;

        // Properties
        public int X 
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y { get { return y; } set { y = value; } }

        public int Z { get; set; }


        // Constructors in C#
        // Default 
        public Point()
        {

        }

        // Parameterised
        public Point(int x, int y)
        {
            this.x = x;
            this.Y = y;
        }


    }

}