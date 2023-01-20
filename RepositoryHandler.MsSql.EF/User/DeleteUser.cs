using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class DeleteUser : IDeleteUser
    {
        private readonly IUserOperation UserOperation;

        public DeleteUser(IUserOperation UserOperation)
        {
            this.UserOperation = UserOperation;
        }

        public async Task ExecuteAsync(int userId)
        {
            await UserOperation.DeleteUserByIdAsync(userId).ConfigureAwait(false);
        }
    }
}
