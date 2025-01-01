using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;

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
         
        public IActionResult GetEmployeeList()
        {
            var data = context.Employees.ToList();
            return new JsonResult(data);
        }
       
    }
}

