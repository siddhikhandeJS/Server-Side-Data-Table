using OrganisationProj1.Entity;
using OrganisationProj1.Repository;

namespace OrganisationProj1.Service
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeDbManager mgr = new EmployeeDbManager();
        public bool AddEmployee(Employee E)
        {
            mgr.AddEmployee(E);
            return true;
            throw new NotImplementedException();
        }

        public bool Delete(int EId)
        {
            mgr.Delete(EId);
            return true;
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return mgr.GetAll();
            throw new NotImplementedException();
        }

        public Employee GetById(int EId)
        {
            return mgr.GetById(EId);
            throw new NotImplementedException();
        }

        public bool Update(Employee e)
        {
            mgr.Update(e);
            return true;
            throw new NotImplementedException();
        }
    }
}
