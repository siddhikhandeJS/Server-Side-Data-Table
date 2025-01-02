using Microsoft.EntityFrameworkCore;
using ServerSideDataTable.Models;

namespace ServerSideDataTable.Data
{
    public class CollectionContext : DbContext
    {
        public CollectionContext(DbContextOptions<CollectionContext> options) : base(options)
        {

        }
        public CollectionContext()
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Siddd\\MSSQLSERVER01;Database=SDATATABLE;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

    }
}
