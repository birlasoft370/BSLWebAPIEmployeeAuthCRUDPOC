using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public string? Department { get; set; }
        public double Salary { get; set; }
    }
}
