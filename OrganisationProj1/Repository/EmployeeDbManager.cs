using System.Net.Http.Headers;
using OrganisationProj1.Entity;

namespace OrganisationProj1.Repository
{
    public class EmployeeDbManager : IEmployeeDbManager
    {
        public bool AddEmployee(Employee e)
        {
            using (var context = new CollectionContext())
            {
                context.Add(e);
                context.SaveChanges();
                return true;
            }
            throw new NotImplementedException();
        }

        public bool Delete(int EId)
        {
            using (var context = new CollectionContext())
            {
                context.Remove(context.Employees.Find(EId));
                context.SaveChanges();
                return true;
            }
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            using (var context = new CollectionContext())
            {
                var employees = from emp in context.Employees select emp;
                return employees.ToList<Employee>();
            }
            throw new NotImplementedException();
        }

        public Employee GetById(int EId)
        {
            using (var context = new CollectionContext())
            {
                var employee = context.Employees.Find(EId);
            }
            throw new NotImplementedException();
        }

        public bool Update(Employee EuId)
        {
            using (var context = new CollectionContext())
            {
                Employee emp = context.Employees.Find(EuId);
                emp.DeptId = EuId.DeptId;
                emp.EmpName = EuId.EmpName;
                emp.Email = EuId.Email;
                emp.Phone = EuId.Phone;
                emp.Designation = EuId.Designation;
                emp.DeptId = EuId.DeptId;
                context.SaveChanges();
                return true;
            }
            throw new NotImplementedException();
        }
    }
}
