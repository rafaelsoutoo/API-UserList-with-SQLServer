using UserList.Infrastructure.Data;
using UserList.Communication.Responses;

namespace UserList.Application.UseCase.Users.GetAll
{
    public class GetAllUserUseCase
    {
        private readonly InfrastructureDbContext contextDB;

        public GetAllUserUseCase(InfrastructureDbContext context)
        {
            contextDB = context;
        }

        public List<ResponseAllUsersJson> Execute()
        {
            var users = contextDB.Users.Select(user => new ResponseAllUsersJson
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();

            return users;
        }
    }
}
