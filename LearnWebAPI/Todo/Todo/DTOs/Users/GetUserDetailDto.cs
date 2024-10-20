using Todo.DTOs.Todos;

namespace Todo.DTOs.Users
{
    public class GetUserDetailDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<GetTodoDto> Todos { get; set; }
    }
}
