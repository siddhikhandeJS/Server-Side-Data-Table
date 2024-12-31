using OrganisationProj1.Entity;

namespace OrganisationProj1.Service
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public bool AddEmployee(Employee p);
        public Employee GetById(int PId);
        public bool Delete(int PId);
        public bool Update(Employee p);
    }
}
