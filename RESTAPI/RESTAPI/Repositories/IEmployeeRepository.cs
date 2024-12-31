using RESTAPI.Models;

namespace RESTAPI.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        bool Insert(Employee employee);
    }
}
