using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class GetUser : IGetUser
    {
        private readonly IUserOperation UserOperatons;

        public GetUser(IUserOperation UserOperatons)
        {
            this.UserOperatons = UserOperatons;
        }

        public async Task<IEnumerable<UserDTO>> ExecuteAsync()
        {
            var result = await UserOperatons.GetAllUser().ConfigureAwait(false);

            return result;
        }
    }
}
