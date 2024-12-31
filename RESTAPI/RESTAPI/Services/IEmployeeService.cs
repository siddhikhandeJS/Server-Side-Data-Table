using RESTAPI.DTO;
using RESTAPI.Models;

namespace RESTAPI.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        bool Insert(Employee employee);
    }
}
