using Todo.Contracts;

namespace Todo.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        RepoContext _context;
        UserRepo _userRepo;
        ToDoRepo _toDoRepo;
        public RepositoryWrapper(RepoContext context)
        {
            _context = context;
        }
        public IUserRepo User
        {
            get
            {
                return _userRepo ?? new UserRepo(_context);
            }
        }
        public ITodoRepo Todos
        {
            get
            {
                return _toDoRepo ?? new ToDoRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
