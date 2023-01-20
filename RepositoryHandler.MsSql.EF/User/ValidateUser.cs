using DomainModel.User;
using Repository;

namespace RepositoryHandler.MsSql.EF.User
{
    public class ValidateUser : IValidateUser
    {
        private readonly IUserOperation userOperations;

        public ValidateUser(IUserOperation userOperations)
        {
            this.userOperations = userOperations;
        }

        public async Task<UserModel> Validate(string username, string password)
        {
            var result = await userOperations.Validate(username, password).ConfigureAwait(false);

            return result;
        }
    }
}
