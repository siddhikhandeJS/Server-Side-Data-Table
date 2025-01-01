using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;
using RESTAPI.DTO;
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
        public ActionResult Index()
        {
            var data = context.Employees.Take(50).ToList();
            return View(data);
        }
        //public JsonResult GetEmployeeRecord(DataTablesParam param)
        //{
        //    List<EmployeeDto> List = new List<EmployeeDto>();
        //    int pageNo = 1;
        //    if (param.iDisplayStart > param.iDisplayLength)
        //    {
        //        pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;

        //    }

        //    int totalCount = 0;

        //    if (param.sSearch != null)
        //    {
        //        totalCount = db.Employees.Where(x => x.EmpName.ToLower().Contains(param.sSearch.ToLower())
        //        || x.Email.Contains(param.sSearch.ToLower())
        //        || x.Phone.Contains(param.sSearch.ToString())
        //        || x.Designation.ToLower().Contains(param.sSearch.ToLower())
        //        ).Count();

        //        List = db.Employees.Where(x => x.EmpName.ToLower().Contains(param.sSearch.ToLower())
        //        || x.Email.Contains(param.sSearch.ToLower())
        //        || x.Phone.Contains(param.sSearch.ToString())
        //        || x.Designation.ToLower().Contains(param.sSearch.ToLower())
        //        ).OrderBy(x => x.EmpId).Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength)
        //        .Select(x => new EmployeeDto
        //        {
        //            EmpName = x.EmpName,
        //            Email = x.Email,
        //            Phone = x.Phone,
        //            Designation = x.Designation
        //        }).ToList();
        //    }
        //    else
        //    {
        //        totalCount = db.Employees.Count();
        //        List = db.Employees.OrderBy(x => x.EmpId).Skip((pageNo - 1) * param.iDisplayLength).Take(param.iDisplayLength)
        //            .Select(x => new EmployeeDto
        //            {
        //                EmpName = x.EmpName,
        //                Email = x.Email,
        //                Phone = x.Phone,
        //                Designation = x.Designation
        //            }).ToList();
        //    }


        //    //attributes names should match in return json
        //    return Json(new
        //    {
        //        aaData = List,
        //        sEcho = param.sEcho,
        //        iTotalDisplayRecords = totalCount,
        //        iTotalRecords = totalCount

        //    }, JsonRequestBehavior.AllowGet);
        //}

    }

}

