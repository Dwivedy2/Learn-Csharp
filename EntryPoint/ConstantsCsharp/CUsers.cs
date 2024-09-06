namespace EntryPoint.ConstantsCsharp
{
    internal class CUsers
    {
        // there are 2 types of constants, const & readonly
        // const - initialised at time of declaration
        // readonly - can be initialised after declaration

        private static int ID;

        public const string USER_NAME = "Default";
        public readonly int id;

        public CUsers()
        {
            // id++; // not allowed
            ID++;
            id = ID;
        }
    }
}
