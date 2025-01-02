using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Todo Item cannot contain more than 100 letters.")]
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }
    }
}
