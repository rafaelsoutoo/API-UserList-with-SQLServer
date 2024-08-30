using Microsoft.AspNetCore.Mvc;
using UserList.Application.UseCase.Users.Delete;
using UserList.Application.UseCase.Users.GetAll;
using UserList.Application.UseCase.Users.Register;
using UserList.Communication.Requests;
using UserList.Communication.Responses;
using UserList.Infrastructure.Data;

namespace UserList.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUseCase;
        private readonly GetAllUserUseCase _getAllUserUseCase;
        private readonly DeleteUserUseCase _deleteUserUseCase;

        public UserController(InfrastructureDbContext context)
        {
            _registerUseCase = new RegisterUserUseCase(context);
            _getAllUserUseCase = new GetAllUserUseCase(context);
            _deleteUserUseCase = new DeleteUserUseCase(context);
        }

        
        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestUserJson request)
        {
            try
            {
                var response = _registerUseCase.Execute(request);
                return CreatedAtAction(nameof(Register), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var response = _deleteUserUseCase.Execute(id);

            if (!response.Success)
            {
                return NotFound(new { message = response.Message });
            }

            return Ok(new { message = response.Message });
        }

    }
}
