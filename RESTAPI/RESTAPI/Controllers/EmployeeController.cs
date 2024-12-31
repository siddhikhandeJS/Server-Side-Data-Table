using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;
using RESTAPI.DTO;
using RESTAPI.Models;
using RESTAPI.Services;

namespace RESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        //Each action method is mapped to HTTP Request type
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        //action method
        [HttpGet]
        [Route("api/employees")]
        public IActionResult GetEmployees()
        {
            //invoke service method to resturn employees
            // send received data as message to outside world
            try
            {
                var message = service.GetEmployees();
                if (message == null)
                {
                    return NotFound();
                }
                return Ok(message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/employees")]
        public IActionResult Insert([FromBody] Employee employee)
        {
            try
            {

                bool status = service.Insert(employee);
                if (status == false)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

    }
}
