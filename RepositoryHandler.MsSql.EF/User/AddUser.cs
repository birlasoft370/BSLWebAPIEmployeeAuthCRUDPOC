using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class AddUser : IAddUser
    {
        private readonly IUserOperation UserOperations;

        public AddUser(IUserOperation UserOperatons)
        {
            this.UserOperations = UserOperatons;
        }

        public async Task<UserDTO> ExecuteAsync(UserDTO User)
        {
            var result = await UserOperations.Add(User).ConfigureAwait(false);

            return result;
        }
    }
}
