namespace Entities.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeProjects> EmployeeProjects { get; set; }
    }
}
