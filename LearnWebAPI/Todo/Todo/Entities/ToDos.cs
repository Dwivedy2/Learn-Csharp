using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Entities
{
    [Table("todos")]
    public class ToDos : HelperEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Item { get; set; }
        public bool IsComplete { get; set; } = false;

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
