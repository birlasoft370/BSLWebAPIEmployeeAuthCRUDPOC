using DomainModel.User;
using MediatR;

namespace DomainModel
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public AddUserRequest()
        {
            UserModel = new();
        }
        public UserModel UserModel
        {
            get; set;
        }
    }
}
