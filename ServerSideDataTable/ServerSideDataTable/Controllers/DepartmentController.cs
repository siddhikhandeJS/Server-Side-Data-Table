using Microsoft.AspNetCore.Mvc;
using ServerSideDataTable.Data;
using ServerSideDataTable.Models;

namespace ServerSideDataTable.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly CollectionContext context;

        public DepartmentController(CollectionContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDepartmentList()
        {
            var data = context.Departments.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddDepartment([FromBody] Department department)
        {
            if (string.IsNullOrWhiteSpace(department.DeptName))
            {
                return new JsonResult("Department name is required.");
            }
            
            context.Departments.Add(department);
            context.SaveChanges();
            return new JsonResult("Department added successfully.");
        }

        public JsonResult EditDepartment(int deptId)
        {
            var department = context.Departments.Where(e => e.DeptId == deptId).SingleOrDefault();
            if (department == null)
            {
                return new JsonResult("Department not found");
            }
            return new JsonResult(department);
        }

        [HttpPost]
        public JsonResult UpdateDepartment([FromBody] Department department)
        {
            if (department == null)
            {
                return new JsonResult("Invalid data provided.");
            }
            context.Departments.Update(department);
            context.SaveChanges();
            return new JsonResult("Department updated successfully.");
}

        [HttpDelete]
        public JsonResult DeleteDepartment(int deptId)
        {
            var department = context.Departments.Find(deptId);
            context.Departments.Remove(department);
            context.SaveChanges();
            return new JsonResult("Department deleted successfully.");
        }
    }
}
