namespace Entities.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<EmployeeSkills> EmployeeSkills { get; set; }
    }
}
