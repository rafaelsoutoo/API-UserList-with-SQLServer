using UserList.Infrastructure.Data;
using UserList.Communication.Responses;

namespace UserList.Application.UseCase.Users.GetAll
{
    public class GetAllUserUseCase
    {
        private readonly InfrastructureDbContext _context;

        public GetAllUserUseCase(InfrastructureDbContext context)
        {
            _context = context;
        }

        public List<ResponseAllUsersJson> Execute()
        {
            var users = _context.Users.Select(user => new ResponseAllUsersJson
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();

            return users;
        }
    }
}
