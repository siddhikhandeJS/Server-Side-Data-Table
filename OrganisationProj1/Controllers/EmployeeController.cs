using Microsoft.AspNetCore.Mvc;
using OrganisationProj1.Entity;
using OrganisationProj1.Service;

namespace OrganisationProj1.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeeService svc = new EmployeeService();
        public IActionResult GetAll()
        {
            List<Employee> employees = svc.GetAll();
            return View(employees);
        }

        public IActionResult AddEmployee(Employee p)
        {
            svc.AddEmployee(p);
            return RedirectToAction("GetAll", "Employee");
        }

        public IActionResult Details(int Id)
        {
            return View(svc.GetById(Id));
        }

        public IActionResult Delete(int Id)
        {
            svc.Delete(Id);
            return RedirectToAction("GetAll", "Employee");
        }
        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Update(Employee e)
        {
            svc.Update(e);
            return RedirectToAction("GetAll", "Employee");
        }
        public IActionResult EditForm(int EId)
        {
            Employee e = svc.GetById(EId);
            return View(e);
        }

    }
}
