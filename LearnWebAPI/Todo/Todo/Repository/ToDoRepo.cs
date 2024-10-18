using Microsoft.EntityFrameworkCore;
using Todo.Contracts;
using Todo.Entities;

namespace Todo.Repository
{
    public class ToDoRepo : ITodoRepo
    {
        RepoContext context;
        public ToDoRepo(RepoContext repoContext)
        {
            context = repoContext;
        }

        public void AddTodo(ToDos todo)
        {
            context.Add(todo);
        }

        public void DeleteTodo(ToDos todo)
        {
            context.Remove(todo);
        }

        public IEnumerable<ToDos> GetAllTodos()
        {
            return context.ToDos.AsNoTracking().ToList();
        }

        public ToDos GetTodoById(int id)
        {
            return context.ToDos.FirstOrDefault(t => t.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateTodo(ToDos todo)
        {
            context.Update(todo);
        }
    }
}