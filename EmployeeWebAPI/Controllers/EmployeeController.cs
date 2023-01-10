using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var employees = await _employeeRepository.GetAllEmployee();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _employeeRepository.GetEmployee(id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            var result = await _employeeRepository.Add(employee);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Employee employee)
        {
            if (employee == null || employee.Id == 0)
                return BadRequest();

            var employee1 = await _employeeRepository.Update(employee);

            return Ok(employee1);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.Delete(id);
            return Ok(employee);
        }
    }
}
