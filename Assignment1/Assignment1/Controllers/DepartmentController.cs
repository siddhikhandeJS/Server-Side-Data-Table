﻿using Assignment1.Entity;
using Assignment1.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public IActionResult AddDept()
        {
            return View(new Department());
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {

            departmentService.AddDepartment(department);
            return RedirectToAction("GetAllDepartments");
        }

        public IActionResult GetAllDepartments()
        {
            var departments = departmentService.GetAllDepartments();
            return View(departments);
        }
    }
}
