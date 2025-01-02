using Assignment1.Entity;

namespace Assignment1.Service
{
    public interface IDepartmentService
    {
       Department AddDepartment(Department department);
        List<Department> GetAllDepartments();
        void DeleteDepartment(int id);

    }
}
