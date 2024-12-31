using Assignment1.Entity;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CollectionContext context;

        public EmployeeRepository(CollectionContext context)
        {
            this.context = context;
        }

        public Employee AddEmployee(Employee e)
        { 
        
            var addEmployee = context.Employees.Add(e).Entity;   //Add employee to context
            context.SaveChanges();   //save changes to db
            return addEmployee;
        }
      

        public bool Delete(int empId)
        {
            var employee = context.Employees.Find(empId);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Employee> GetAll()
        {
            return context.Employees.Include(e => e.Department).ToList();
        }

        public Employee GetById(int id)
        {
            var employee = context.Employees.Find(id);
            return employee;
        }


        public Employee Update(Employee e)
        {
            var employee = context.Employees.Find(e.EmpId); // Fetch the existing employee
            if(employee == null)
            {
                return null;
            }
            // Update the properties
            employee.EmpName = e.EmpName;
            employee.Email = e.Email;
            employee.Phone = e.Phone;
            employee.Designation = e.Designation;
            employee.DeptId = e.DeptId;
            context.SaveChanges(); // Save changes to the database
            return employee;
        }

    }
}
