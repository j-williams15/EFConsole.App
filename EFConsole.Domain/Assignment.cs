using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeApp.Domain
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public Assignment(Guid employeeId)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
        }
    }
    public class Employee
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Employee()
        {
            Id = Guid.NewGuid();
        }
    }
}
