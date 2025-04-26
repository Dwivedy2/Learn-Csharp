public enum Roles
{
    Developer,
    QualityAssurance,
    Devops,
    ITIS,
}

namespace Entities.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public Roles Role { get; set; }
        public int Age { get; set; }
    }
}
