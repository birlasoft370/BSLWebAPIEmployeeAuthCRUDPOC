using DomainModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    public class LoginCQRSController : ControllerBase
    {
        private readonly IMediator mediator;
        public LoginCQRSController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("api/v1/[controller]/ValidateUser")]
        public async Task<IActionResult> AddEmployee([FromBody] ValidateUserRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
