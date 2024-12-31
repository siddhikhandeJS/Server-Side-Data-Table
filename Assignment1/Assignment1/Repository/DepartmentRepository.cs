using Assignment1.Entity;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CollectionContext context;

        public DepartmentRepository(CollectionContext context)
        {
            this.context = context;
        }

        public Department AddDepartment(Department department)
        {
            var addDept = context.Add(department).Entity;
            context.SaveChanges();
            return addDept;
        }

        public List<Department> GetAllDepartments()
        {
            return context.Departments.ToList();
        }
    }
}
