using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSideDataTable.Data;
using ServerSideDataTable.Models;

namespace ServerSideDataTable.Controllers
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

        [HttpPost]
        public JsonResult GetEmployeeList()
        {
            var data = context.Employees.Include(e => e.Department)
                        .Select(e => new
                        {
                            e.EmpId,
                            e.EmpName,
                            e.Email,
                            e.Phone,
                            e.Designation,
                            DeptName = e.Department != null ? e.Department.DeptName : "Unassigned"
                        }).ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddEmployee([FromBody] Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.EmpName) || string.IsNullOrWhiteSpace(employee.Email) ||
                string.IsNullOrWhiteSpace(employee.Phone) || string.IsNullOrWhiteSpace(employee.Designation))
            {
                return new JsonResult("All fields are required.");
            }

            context.Employees.Add(employee);
            context.SaveChanges();
            return new JsonResult("Employee added successfully.");
        }

        [HttpPost]
        public JsonResult EditEmployee(int empId)
        {
            var employee = context.Employees.Find(empId);
            return new JsonResult(employee);
        }

        [HttpPost]
        public JsonResult UpdateEmployee([FromBody] Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
            return new JsonResult("Employee updated successfully.");
        }

        [HttpDelete]
        public JsonResult DeleteEmployee(int empId)
        {
            var employee = context.Employees.Find(empId);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return new JsonResult("Employee deleted successfully.");
        }

        public JsonResult GetDepartments()
        {
            var departments = context.Departments.Select(d => new { d.DeptId, d.DeptName }).ToList();
            return new JsonResult(departments);
        }
    }
}
