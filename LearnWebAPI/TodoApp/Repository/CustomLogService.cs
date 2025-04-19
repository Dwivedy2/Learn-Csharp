using Contract;

namespace Repository
{
    public class CustomLogService : ICustomLogService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
