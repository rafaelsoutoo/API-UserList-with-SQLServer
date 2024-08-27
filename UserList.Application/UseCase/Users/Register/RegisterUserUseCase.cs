using UserList.Communication.Requests;
using UserList.Communication.Responses;
using UserList.Infrastructure.Data;
using UserList.Infrastructure.Models;

namespace UserList.Application.UseCase.Users.Register
{
    public class RegisterUserUseCase
    {
        private readonly InfrastructureDbContext contextDB;

        public RegisterUserUseCase(InfrastructureDbContext context)
        {
            contextDB = context;
        }

        public ResponseRegisterUserJson Execute(RequestUserJson request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password

            };

            contextDB.Users.Add(user);// Adiciona o novo usuário ao contexto
            contextDB.SaveChanges();// Persiste as mudanças no banco de dados

            return new ResponseRegisterUserJson
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
