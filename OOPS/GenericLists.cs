namespace OOPS
{
    internal class GenericLists
    {
        public static void Start()
        {
            // Initialization techniques

            // List<int> numbers = new List<int>();

            // List<int> numbersWithInitialCapacity = new List<int>(10);

            int[] marks = new int[5] { 1, 2, 3, 4, 5 };

            List<int> marksList = new List<int>(marks);

            // Get from the list
            int mathsMarks = marksList[0];

            // Add to the list
            marksList.Add(6);
            marksList.Add(7);
            marksList.Add(8);
            marksList.Add(9);

            // Add a whole array, like in the constructor
            marksList.AddRange(marks);

            bool isZeroContained = marksList.Contains(0);

            int indexOfZero = marksList.IndexOf(0); // returns -1, if not found

            // Dictionary
            Dictionary<string, int> mp = new Dictionary<string, int>();
            Dictionary<string, int> mp1 = new Dictionary<string, int>(10); // capacity
            Dictionary<string, int> mp2 = new Dictionary<string, int>(mp1); // from the above dictionary

            mp.Add("Maths", 98);
            mp.Add("English", 80);

            foreach (var item in mp)
            {
                if (mp.ContainsKey(item.Key) && mp.ContainsValue(mp[item.Key]))
                {
                    Console.WriteLine($"Key: {item.Key}, Value: {mp[item.Key]}");
                }
            }

            mp.Clear();
            marksList.Clear();
        }
    }
}
