using EmpDept.Data;
using EmpDept.Models;
using EmpDept.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpDept.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                EmpName = viewModel.EmpName,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Designation = viewModel.Designation,
                DeptId = viewModel.DeptId
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await dbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var employee = await dbContext.Employees.FindAsync(Id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var employee = await dbContext.Employees.FindAsync(viewModel.EmpId);

            if(employee is not null)
            {
                employee.EmpName = viewModel.EmpName;
                employee.Email = viewModel.Email;
                employee.Phone = viewModel.Phone;
                employee.Designation = viewModel.Designation;
                employee.DeptId = viewModel.DeptId;

                await dbContext.SaveChangesAsync(); 
            }

            return RedirectToAction("GetAllEmployee", "Employees");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel) {
            var employee = await dbContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EmpId == viewModel.EmpId);
            if(employee is not null)
            {
                dbContext.Employees.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }

    }
}
