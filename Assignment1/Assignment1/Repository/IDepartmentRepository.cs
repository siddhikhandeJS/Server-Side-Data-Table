using Assignment1.Entity;

namespace Assignment1.Repository
{
    public interface IDepartmentRepository
    {
        Department AddDepartment(Department department);

        void DeleteDepartment(int id);
        void Save();
        List<Department> GetAllDepartments();
    }
}
