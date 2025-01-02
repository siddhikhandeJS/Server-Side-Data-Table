using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;

namespace RESTAPI.Controllers
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
    }
}
