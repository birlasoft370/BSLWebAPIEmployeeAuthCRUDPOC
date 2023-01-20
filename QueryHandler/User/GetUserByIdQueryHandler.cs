using AutoMapper;
using DomainModel.User;
using MediatR;
using Repository;

namespace QueryHandler
{
    public class GetUserById
    {
        public class GetUserByIdQuery : IRequest<UserModel>
        {
            public int Id { get; set; }
        }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
        {
            private readonly IGetUserById UserById;
            private readonly IMapper mapper;

            public GetUserByIdQueryHandler(IGetUserById UserById, IMapper mapper)
            {
                this.UserById = UserById;
                this.mapper = mapper;
            }

            public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var UserDto = await this.UserById.ExecuteAsync(request.Id).ConfigureAwait(false);
                var UserModel = mapper.Map<UserModel>(UserDto);
                return UserModel;
            }
        }
    }
}