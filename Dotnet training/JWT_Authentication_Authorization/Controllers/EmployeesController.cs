using JWT_Authentication_Authorization.Interfaces;
using JWT_Authentication_Authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWT_Authentication_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //// GET: api/<EmployeesController>
        //[HttpGet]
        //[Authorize(Roles = "User,Admin")]
        //public List<Employee> GetEmployees()
        //{
        //    return _employeeService.GetEmployeeList();
        //}

        // GET: api/<EmployeesController>
        [HttpGet]
        //[Authorize(Roles = "User,Admin")]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployeeList();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while fetching the employee list.");
            }
        }




        // POST api/<EmployeesController>
        [HttpPost]
        [Authorize]
        public Employee AddEmployee([FromBody] Employee emp)
        {
            var employee = _employeeService.AddEmployee(emp);
            return employee;
        }


    }
}