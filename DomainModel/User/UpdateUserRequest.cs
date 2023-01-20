using DomainModel.User;
using MediatR;

namespace DomainModel
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public UpdateUserRequest()
        {
            UserModel = new();
        }

        public UserModel UserModel { get; set; }

    }
}
