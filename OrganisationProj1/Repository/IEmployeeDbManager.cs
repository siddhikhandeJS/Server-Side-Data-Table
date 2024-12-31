using OrganisationProj1.Entity;

namespace OrganisationProj1.Repository
{
    public interface IEmployeeDbManager
    {
        public List<Employee> GetAll();
        public bool AddEmployee(Employee e);
        public Employee GetById(int EId);
        public bool Delete(int EId);
        public bool Update(Employee EuId);

    }
}
