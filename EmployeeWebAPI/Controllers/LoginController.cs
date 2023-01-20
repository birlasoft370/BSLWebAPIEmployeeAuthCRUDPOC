using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public LoginController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetAsync(User user)
        {
            var userValid = await _usersRepository.ValidateUser(user.Username, user.Password);
            return Ok(userValid);
        }
    }
}
