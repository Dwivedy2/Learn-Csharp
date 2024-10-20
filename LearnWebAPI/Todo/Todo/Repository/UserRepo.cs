using Microsoft.EntityFrameworkCore;
using Todo.Contracts;
using Todo.Entities;

namespace Todo.Repository
{
    public class UserRepo : IUserRepo
    {
        RepoContext _context;
        public UserRepo(RepoContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.AsNoTracking().ToList();
        }

        public User? GetById(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        public User? GetDetailById(int id)
        {
            return _context.User
                .Where(x => x.Id == id)
                .AsNoTracking()
                .Include(x => x.Todos)
                .FirstOrDefault();
        }
    }
}
