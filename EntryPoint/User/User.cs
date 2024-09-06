namespace EntryPoint.User
{
    internal class User
    {
        private string username;
        private string password;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value.Length < 4 || value.Length > 10)
                    Console.WriteLine("Not a valid username");

                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value.Length < 4 || value.Length > 10)
                    Console.WriteLine("Not a valid password");

                password = value;
            }
        }
    }
}
