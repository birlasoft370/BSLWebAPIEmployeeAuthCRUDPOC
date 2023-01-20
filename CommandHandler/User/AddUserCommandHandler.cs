using AutoMapper;
using DataEntity;
using DomainModel;
using DomainModel.User;
using MediatR;
using Repository;

namespace CommandHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IAddUser addUser;
        private readonly IMapper mapper;

        public AddUserCommandHandler(IAddUser addUser, IMapper mapper)
        {
            this.addUser = addUser;
            this.mapper = mapper;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var UserDto = mapper.Map<UserDTO>(request.UserModel);
            var result = await this.addUser.ExecuteAsync(UserDto).ConfigureAwait(false);
            var entity = mapper.Map<UserModel>(result);

            return new AddUserResponse()
            {
                UserModel = entity
            };
        }
    }
}
