using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkWithDotnet6.Models
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
    }
}
