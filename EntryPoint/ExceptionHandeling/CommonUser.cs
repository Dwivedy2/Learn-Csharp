using EntryPoint.Enums;

namespace EntryPoint.ExceptionHandeling
{
    public class CommonUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        private static int _id = 0;
        public Race race;
        public CommonUser() 
        {
            _id++;
            Id = _id;
        }

        public CommonUser(string? name)
        {
            _id++;
            Id = _id;
            Name = name;
        }
    }
}
