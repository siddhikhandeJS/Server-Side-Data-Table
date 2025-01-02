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
        public JsonResult AddEmployee([FromBody] Employee employee)
        {
            // Validate if any field is empty
            if (string.IsNullOrWhiteSpace(employee.EmpName) ||
                string.IsNullOrWhiteSpace(employee.Email) ||
                string.IsNullOrWhiteSpace(employee.Phone) ||
                string.IsNullOrWhiteSpace(employee.Designation))
            {
                return new JsonResult("All fields are required.");
            }

            var emp = new Employee()
            {
                EmpName = employee.EmpName,
                Email = employee.Email,
                Phone = employee.Phone,
                Designation = employee.Designation
            };
            context.Employees.Add(emp);
            context.SaveChanges();
            return new JsonResult("Data added successfully");
   
        }

        [HttpDelete]
        public JsonResult Delete(int empId)
        {
            var employee = context.Employees.Find(empId);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return new JsonResult("Employee Deleted");
        }

        
        public JsonResult Edit(int empId)
        {
            var employee = context.Employees.Where(e => e.EmpId == empId).SingleOrDefault();
            return new JsonResult(employee);
        }

        [HttpPost]
        public JsonResult Update(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
            return new JsonResult("Record Updated!");
        }
    }
}

