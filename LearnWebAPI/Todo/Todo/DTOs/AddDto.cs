using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
    public class AddDto
    {
        [Required]
        public string? Item { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
