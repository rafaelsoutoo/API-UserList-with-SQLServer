using Microsoft.AspNetCore.Mvc;
using UserList.Application.UseCase.Users.GetAll;
using UserList.Application.UseCase.Users.Register;
using UserList.Communication.Requests;
using UserList.Communication.Responses;
using UserList.Infrastructure.Data;

namespace Register.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUseCase;
        private readonly GetAllUserUseCase _getAllUserUseCase;

        public UserController(InfrastructureDbContext context)
        {
            _registerUseCase = new RegisterUserUseCase(context);
            _getAllUserUseCase = new GetAllUserUseCase(context);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public IActionResult Register([FromBody] RequestUserJson request)
        {
            var response = _registerUseCase.Execute(request);
            return CreatedAtAction(nameof(Register), new { id = response.Id }, response);
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(List<ResponseAllUsersJson>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllUsers()
        {
            var users = _getAllUserUseCase.Execute();

            if (users == null || users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }
    }
}
