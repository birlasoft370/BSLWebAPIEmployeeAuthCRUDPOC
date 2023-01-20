using AutoMapper;
using DomainModel.Department;
using MediatR;
using Repository;

namespace QueryHandler
{
    public class GetAllDepartment
    {
        public class GetAllDepartmentQuery : IRequest<IEnumerable<DepartmentModel>>
        {
        }

        public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IEnumerable<DepartmentModel>>
        {
            private readonly IGetDepartments _departmentRespository;
            private readonly IMapper mapper;
            public GetAllDepartmentQueryHandler(IGetDepartments departmentRespository, IMapper mapper)
            {
                this._departmentRespository = departmentRespository;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<DepartmentModel>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
            {
                var departmentDto = await this._departmentRespository.ExecuteAsync().ConfigureAwait(false);
                var departmentModel = mapper.Map<IEnumerable<DepartmentModel>>(departmentDto);
                return departmentModel;
            }
        }
    }   
}