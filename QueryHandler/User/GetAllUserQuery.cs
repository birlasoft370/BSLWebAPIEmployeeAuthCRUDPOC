using AutoMapper;
using DomainModel.User;
using MediatR;
using Repository;

namespace QueryHandler
{
    public class GetAllUser
    {
        public class GetAllUserQuery : IRequest<IEnumerable<UserModel>>
        {
        }

        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserModel>>
        {
            private readonly IGetUser _UserRespository;
            private readonly IMapper mapper;
            public GetAllUserQueryHandler(IGetUser UserRespository, IMapper mapper)
            {
                this._UserRespository = UserRespository;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<UserModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var UserDto = await this._UserRespository.ExecuteAsync().ConfigureAwait(false);
                var UserModel = mapper.Map<IEnumerable<UserModel>>(UserDto);
                return UserModel;
            }
        }
    }   
}