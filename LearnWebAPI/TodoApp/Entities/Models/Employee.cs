using Constants.Enums;
using Entities.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [NoSpecialCharacters(ErrorMessage = "No special characters are allowed for name")]
        public string? Name { get; set; }
        public Roles Role { get; set; }
        [Range(18, 65, ErrorMessage = "Age must be in between 18 and 65")]
        public int Age { get; set; }
        [EmailAddress]
        [NoPersonalEmailAllowed(ErrorMessage = "Provide only company email id")]
        public string? Email { get; set; }

        public ICollection<EmployeeSkills> EmployeeSkills { get; set; }
        public ICollection<EmployeeProjects> EmployeeProjects { get; set; }
    }
}
