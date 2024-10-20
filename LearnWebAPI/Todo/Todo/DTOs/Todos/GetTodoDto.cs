using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs.Todos
{
    public class GetTodoDto
    {
        public int Id { get; set; }
        [Required]
        public string? Item { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
