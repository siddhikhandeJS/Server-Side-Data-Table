using System;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Data;
using RESTAPI.Models;

namespace RESTAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //private readonly CollectionContext context;

        //public EmployeeRepository(CollectionContext context)
        //{
        //    this.context = context;
        //}

        public List<Employee> GetEmployees()
        {
            using (var context = new CollectionContext())
            {
                var employees = from prod in context.Employees select prod;
                return employees.ToList<Employee>();
            }
        }

        public bool Insert(Employee employee)
        {
            using (var context = new CollectionContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
            return true;
        }
    }
}
