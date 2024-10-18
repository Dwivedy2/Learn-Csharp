using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Entities
{
    [Table("todos")]
    public class ToDos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Item { get; set; }
        public bool IsComplete { get; set; } = false;
    }
}
