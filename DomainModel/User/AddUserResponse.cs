using DomainModel.User;

namespace DomainModel
{
    public class AddUserResponse
    {
        public AddUserResponse()
        {
            UserModel = new();
        }
        public UserModel UserModel { get; set; }
    }
}
