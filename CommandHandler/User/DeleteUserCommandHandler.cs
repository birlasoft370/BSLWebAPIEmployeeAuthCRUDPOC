using DomainModel;
using MediatR;
using Repository;

namespace CommandHandler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IDeleteUser deleteUser;

        public DeleteUserCommandHandler(IDeleteUser deleteUser)
        {
            this.deleteUser = deleteUser;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            await this.deleteUser.ExecuteAsync(request.UserId).ConfigureAwait(false);
            return new DeleteUserResponse() { UserId = request.UserId };
        }
    }
}
