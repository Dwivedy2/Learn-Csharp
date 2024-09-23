namespace OOPS
{
    internal class Generics
    {
        public static void Start()
        {
            GenericCollection<int> marksCollection = new GenericCollection<int>(5);
            marksCollection.InitialiseWithValues(99, 98, 54, 63, 89);
            int marks = marksCollection.GetValue(3);
            Console.WriteLine("Marks: " + marks);

            GenericCollection<char> stringCollection = new GenericCollection<char>(5);
            marksCollection.InitialiseWithValues('h', 'e', 'l', 'l', 'o');
            char character = stringCollection.GetValue(3);
            Console.WriteLine("Character: " + character);
        }
    }

    class GenericCollection<T>
    {
        T[] array;
        public GenericCollection(int size) 
        { 
            array = new T[size];
        }

        public void InitialiseWithValues(params T[] values)
        {
            for (int i = 0; i < values.Length; i++) 
            {
                array[i] = values[i];
            }
        }

        public T GetValue(int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new ArgumentException("Index is not valid");
            }
            else
            {
                return array[index];
            }
        }

    }
}
