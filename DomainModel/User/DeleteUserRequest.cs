using MediatR;

namespace DomainModel
{
    public class DeleteUserRequest: IRequest<DeleteUserResponse>
    {
        public int UserId { get; set; }
    }
}
