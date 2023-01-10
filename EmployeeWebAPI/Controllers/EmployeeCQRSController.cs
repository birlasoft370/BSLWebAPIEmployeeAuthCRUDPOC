using DomainModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryHandler;

namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    public class EmployeeCQRSController : ControllerBase
    {
        private readonly IMediator mediator;
        public EmployeeCQRSController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("api/v1/[controller]/getAllEmployee")]
        public async Task<IActionResult> GetAsync()
        {
            var employees = await mediator.Send(new GetAllEmployee.GetAllEmployeeQuery());
            return Ok(employees);
        }

        [HttpGet]
        [Route("api/v1/[controller]/getEmployeeById")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] int id)
        {
            var employees = await mediator.Send(new GetEmployeeById.GetEmployeeByIdQuery { Id = id });
            return Ok(employees);
        }

        [HttpPost]
        [Route("api/v1/[controller]/addEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/v1/[controller]/updateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/v1/[controller]/deleteEmployee")]
        public async Task<IActionResult> DeleteEmployee([FromQuery] DeleteEmployeeRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
