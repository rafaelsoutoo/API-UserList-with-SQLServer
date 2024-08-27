using UserList.Communication.Responses;
using UserList.Infrastructure.Data;

namespace UserList.Application.UseCase.Users.Delete
{
    public class DeleteUserUseCase
    {
        private readonly InfrastructureDbContext contextDB;

        public DeleteUserUseCase(InfrastructureDbContext context)
        {
            contextDB = context;
        }

        public ResponseDeleteUserJson Execute(Guid userId)
        {
            var user = contextDB.Users.Find(userId);

            if (user == null)
            {

                return new ResponseDeleteUserJson
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            contextDB.Users.Remove(user);
            contextDB.SaveChanges(); // Persiste as mudanças no banco de dados

            return new ResponseDeleteUserJson
            {
                Success = true,
                Message = "User deleted successfully"
            };
        }


    }
}
