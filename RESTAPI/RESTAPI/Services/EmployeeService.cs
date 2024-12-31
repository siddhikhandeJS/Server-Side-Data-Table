using RESTAPI.DTO;
using RESTAPI.Models;
using RESTAPI.Repositories;

namespace RESTAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public List<Employee> GetEmployees()
        {
            if (repository != null)
            {
                return repository.GetEmployees();
            }
            return null;
        }

        public bool Insert(Employee employee)
        {
            return repository.Insert(employee);
        }
    }
}
