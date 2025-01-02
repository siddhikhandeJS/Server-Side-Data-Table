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

        public void DeleteDepartment(int id)
        {
            var department = context.Departments.Find(id);
            if (department != null)
            {
                // Set DeptId to null in associated Employee records
                var employees = context.Employees.Where(e => e.DeptId == id).ToList();
                foreach (var employee in employees)
                {
                    employee.DeptId = null;
                }

                // Remove department record
                context.Departments.Remove(department);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
