using EmployeeApp.Data;
using EmployeeApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.UI
{
    class Program
    {
        private static AssignmentContext _context = new AssignmentContext();
        public static void CreateAssignment()
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                LastName = "Doe",
                FirstName = "John",
            };
            var assignment = new Assignment(employee.Id)
            {
                Name = "IT Department",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now
            };
            Console.Write("\n Assignment " + employee.LastName + ", " + employee.FirstName + " has been created.");
            _context.Employees.Add(employee);
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
        }
        public static void ReadAssignment(string text)
        {
            var assignments = _context.Assignments.ToList();
            Console.WriteLine($"{text} Here are the {assignments.Count} assignment(s) which are present in the database.");
            int i = 1;
            foreach (var assignment in assignments)
            {
                Console.WriteLine($"{text}{i}. ,{ assignment.EmployeeId},{ assignment.Employee}, { assignment.EndDate}, { assignment.Name}, {assignment.StartDate}");
                i++;
            }
        }
        public static void UpdateAssignment()
        {
            var assignments = _context.Assignments.ToList();
            var assignmentToUpdate = assignments[0];
            _context.Assignments.Update(assignmentToUpdate);
            _context.SaveChanges();
            Console.WriteLine("Assignment Updated");
        }
        public static void DeleteAssignment()
        {
            var assignments = _context.Assignments.ToList();
            var assignmentToDelete = assignments[assignments.Count - 1];
            _context.Assignments.Remove(assignmentToDelete);
            _context.SaveChanges();
            Console.WriteLine("Assignment Deleted");
        }

        static void Main()
        {
            CreateAssignment();
            ReadAssignment("");
            UpdateAssignment();
            DeleteAssignment();
     
        }

    }
}