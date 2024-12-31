using Microsoft.EntityFrameworkCore;
using Assignment1.Entity;

namespace Assignment1.Repository
{
    public class CollectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public CollectionContext(DbContextOptions<CollectionContext> contextOptions) : base(contextOptions)
        {
        }

        public CollectionContext()
        {
        }


    }
}
