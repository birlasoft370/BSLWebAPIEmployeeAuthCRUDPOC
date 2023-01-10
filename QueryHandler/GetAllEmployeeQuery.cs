using AutoMapper;
using DataEntity;
using DomainModel;
using MediatR;
using Repository;

namespace QueryHandler
{
    public class GetAllEmployee
    {
        public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeModel>>
        {
        }

        public class EmployeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeModel>>
        {
            private readonly IGetEmployees _employeeRespository;
            private readonly IMapper mapper;
            public EmployeQueryHandler(IGetEmployees employeeRespository, IMapper mapper)
            {
                this._employeeRespository = employeeRespository;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<EmployeeModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
                var employeeDto = await this._employeeRespository.ExecuteAsync().ConfigureAwait(false);
                var employeeModel = mapper.Map<IEnumerable<EmployeeModel>>(employeeDto);
                return employeeModel;
            }
        }
    }   
}