using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly CollectionContext context;

        public EmployeeController(CollectionContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
         
        public JsonResult GetEmployeeList()
        {
            var data = context.Employees.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            var emp = new Employee()
            {
                EmpName = employee.EmpName,
                Email = employee.Email,
                Phone = employee.Phone,
                Designation = employee.Designation
            };
            context.Employees.Add(emp);
            context.SaveChanges();
            return new JsonResult("Data is added");
        }

        [HttpDelete]
        public JsonResult Delete(int empId)
        {
            var employee = context.Employees.Find(empId);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return new JsonResult("Employee Deleted");
        }

        [HttpGet]
        public JsonResult Edit(int empId)
        {
            var employee = context.Employees.Find(empId);
            return new JsonResult(employee);
        }
    }
}

