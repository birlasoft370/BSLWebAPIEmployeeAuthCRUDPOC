using AutoMapper;
using DataEntity;
using DomainModel;
using MediatR;
using Repository;

namespace CommandHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUpdateUser updateUser;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUpdateUser updateUser, IMapper mapper)
        {
            this.updateUser = updateUser;
            this.mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var UserDto = mapper.Map<UserDTO>(request.UserModel);
            await this.updateUser.ExecuteAsync(UserDto).ConfigureAwait(false);

            return new UpdateUserResponse()
            {
                UserModel = request.UserModel
            };
        }
    }

}
