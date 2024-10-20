using Todo.Entities;

namespace Todo.Contracts
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();
        User? GetById(int id);
        User? GetDetailById(int id);
    }
}
