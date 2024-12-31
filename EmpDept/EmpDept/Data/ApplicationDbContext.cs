using EmpDept.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpDept.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



    }
}
