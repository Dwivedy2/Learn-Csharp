using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Entities
{
    [Table("user")]
    public class User : HelperEntity
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<ToDos> Todos { get; set; }
    }
}
