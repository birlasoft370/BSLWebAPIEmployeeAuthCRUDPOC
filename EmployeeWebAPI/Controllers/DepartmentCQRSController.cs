using DomainModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryHandler;

namespace DepartmentWebAPI.Controllers
{
    [ApiController]
    public class DepartmentCQRSController : ControllerBase
    {
        private readonly IMediator mediator;
        public DepartmentCQRSController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("api/v1/[controller]/getAllDepartment")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await mediator.Send(new GetAllDepartment.GetAllDepartmentQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("api/v1/[controller]/getDepartmentById")]
        public async Task<IActionResult> GetDepartmentById([FromQuery] int id)
        {
            var result = await mediator.Send(new GetDepartmentById.GetDepartmentByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Route("api/v1/[controller]/addDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/v1/[controller]/updateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/v1/[controller]/deleteDepartment")]
        public async Task<IActionResult> DeleteDepartment([FromQuery] DeleteDepartmentRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
