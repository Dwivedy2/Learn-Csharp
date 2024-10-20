using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs.Todos
{
    public class AddDto
    {
        [Required]
        public string? Item { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
