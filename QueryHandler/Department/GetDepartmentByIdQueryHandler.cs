using AutoMapper;
using DomainModel.Department;
using MediatR;
using Repository;

namespace QueryHandler
{
    public class GetDepartmentById
    {
        public class GetDepartmentByIdQuery : IRequest<DepartmentModel>
        {
            public int Id { get; set; }
        }

        public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentModel>
        {
            private readonly IGetDepartmentById DepartmentById;
            private readonly IMapper mapper;

            public GetDepartmentByIdQueryHandler(IGetDepartmentById DepartmentById, IMapper mapper)
            {
                this.DepartmentById = DepartmentById;
                this.mapper = mapper;
            }

            public async Task<DepartmentModel> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
            {
                var DepartmentDto = await this.DepartmentById.ExecuteAsync(request.Id).ConfigureAwait(false);
                var DepartmentModel = mapper.Map<DepartmentModel>(DepartmentDto);
                return DepartmentModel;
            }
        }
    }
}