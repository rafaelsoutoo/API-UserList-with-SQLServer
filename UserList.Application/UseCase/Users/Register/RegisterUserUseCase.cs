using UserList.Communication.Requests;
using UserList.Communication.Responses;
using UserList.Infrastructure.Data;
using UserList.Infrastructure.Models;

namespace UserList.Application.UseCase.Users.Register
{
    public class RegisterUserUseCase
    {
        private readonly InfrastructureDbContext _context;

        public RegisterUserUseCase(InfrastructureDbContext context)
        {
            _context = context;
        }

        public ResponseRegisterUserJson Execute(RequestUserJson request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password

            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResponseRegisterUserJson
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
