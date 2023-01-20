using DomainModel.User;

namespace DomainModel
{
    public class UpdateUserResponse
    {
        public UpdateUserResponse()
        {
            UserModel = new();
        }

        public UserModel UserModel { get; set; }
    }
}
