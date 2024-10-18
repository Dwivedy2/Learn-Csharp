using Todo.Entities;

namespace Todo.Contracts
{
    public interface ITodoRepo
    {
        IEnumerable<ToDos> GetAllTodos();
        ToDos GetTodoById(int id);
        void AddTodo(ToDos todo);
        void UpdateTodo(ToDos todo);
        void DeleteTodo(ToDos toDo);
        void Save();
    }
}
