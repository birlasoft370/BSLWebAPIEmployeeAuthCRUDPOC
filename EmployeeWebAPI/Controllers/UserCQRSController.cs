using DomainModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryHandler;

namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    public class UserCQRSController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserCQRSController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("api/v1/[controller]/getAllUser")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await mediator.Send(new GetAllUser.GetAllUserQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("api/v1/[controller]/getUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            var result = await mediator.Send(new GetUserById.GetUserByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Route("api/v1/[controller]/addUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/v1/[controller]/updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/v1/[controller]/deleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserRequest request)
        {
            var result = await mediator.Send(request).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
