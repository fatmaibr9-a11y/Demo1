using Demo1.Data;
using Demo1.Model;
using Demo1.Repo.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private readonly IGenaric<Employee> _employeeRepo;
        public EmployeeController(AppDbContext context, IGenaric<Employee> employeeRepo)
        {
            _Context = context;
            _employeeRepo = employeeRepo;
        }
        [HttpGet("get all employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeRepo.GetAll().ToList();
            return Ok(employees);
        }
        [HttpPost("add employee")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null");
            }
            var e = new Employee
            {
                FullName = employee.FullName,
                Email = employee.Email,
                Phone = employee.Phone,
                Position = employee.Position,
                HireDate = employee.HireDate,
                Sales = employee.Sales,
            };
            _employeeRepo.Add(e);
            _employeeRepo.save();
            return Ok(e);
        }

        [HttpPut("update employee {id}")]
        public IActionResult EditEmployee(Employee employee, int id)
        {
            var existingEmployee = _employeeRepo.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound("Employee not found");
            }
       
            _employeeRepo.Delete(existingEmployee);
            _employeeRepo.save();
            return Ok(existingEmployee);
        }
    }
}
