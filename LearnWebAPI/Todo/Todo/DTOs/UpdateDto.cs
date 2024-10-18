using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
    public class UpdateDto
    {
        [Required]
        public string? Item { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
