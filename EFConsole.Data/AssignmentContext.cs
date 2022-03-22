using Microsoft.EntityFrameworkCore;
using EmployeeApp.Domain;

namespace EmployeeApp.Data
{
    public class AssignmentContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {   //secondary(child) tabledata must be generated and inserted before primary (parent) table data can be inserted.
            modelbuilder.Entity<Employee>().HasData(//Child
            new
            {
                Id = Guid.NewGuid(),
                LastName = "Assinment.LastName",
                FirstName = "Assinment.FirstName",
            });           
            modelbuilder.Entity<Assignment>().HasData(//Parent
            new
            {
                Id = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                EndDate = DateTime.Now,
                Name = "UnnamedDpt",
                StartDate = DateTime.Now
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(
                "Data Source=.;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
