using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class GetUserById : IGetUserById
    {
        private readonly IUserOperation UserOperatons;

        public GetUserById(IUserOperation UserOperatons)
        {
            this.UserOperatons = UserOperatons;
        }

        public async Task<UserDTO> ExecuteAsync(int userId)
        {
            return await UserOperatons.GetUserById(userId).ConfigureAwait(false);
        }
    }
}
