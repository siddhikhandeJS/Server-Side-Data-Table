using Assignment1.Entity;
using Assignment1.Repository;

namespace Assignment1.Service
{
    public class DepartmentService  : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public Department AddDepartment(Department department)
        {
            var addDept = departmentRepository.AddDepartment(department);
            return addDept;
         
        }

        public List<Department> GetAllDepartments()
        {
            return departmentRepository.GetAllDepartments();
        }
    }
}
