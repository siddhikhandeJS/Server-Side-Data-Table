using Microsoft.EntityFrameworkCore;
using OrganisationProj1.Entity;

namespace OrganisationProj1.Repository
{
    public class CollectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public CollectionContext(DbContextOptions<CollectionContext> contextOptions) : base(contextOptions)
        {

        }

        //public CollectionContext()
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string ConnectionString = @"server=localhost;  port=3306; user=root; password=root123; database=organisation";
        //    optionsBuilder.UseMySql(ConnectionString);
        //}



    }
}
