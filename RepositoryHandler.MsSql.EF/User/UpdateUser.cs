using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class UpdateUser : IUpdateUser
    {
        private readonly IUserOperation UserOperations;

        public UpdateUser(IUserOperation UserOperatons)
        {
            this.UserOperations = UserOperatons;
        }

        public async Task<UserDTO> ExecuteAsync(UserDTO User)
        {
            var result = await UserOperations.Update(User).ConfigureAwait(false);

            return result;
        }
    }
}
