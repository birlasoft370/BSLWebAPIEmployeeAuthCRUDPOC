using DomainModel;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class ValidateUser : IValidateUser
    {
        private readonly IuserOperation userOperations;

        public ValidateUser(IuserOperation userOperations)
        {
            this.userOperations = userOperations;
        }

        public async Task<UserModel> Validate(string username, string password)
        {
            var result = await userOperations.Validate(username,password).ConfigureAwait(false);

            return result;
        }
    }
}
