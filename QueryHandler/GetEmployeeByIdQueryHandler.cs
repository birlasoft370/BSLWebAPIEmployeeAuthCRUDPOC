using AutoMapper;
using DataEntity;
using DomainModel;
using MediatR;
using Repository;

namespace QueryHandler
{
    public class GetEmployeeById
    {
        public class GetEmployeeByIdQuery : IRequest<EmployeeModel>
        {
            public int Id { get; set; }
        }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeModel>
        {
            private readonly IGetEmployeeById employeeById;
            private readonly IMapper mapper;

            public GetEmployeeByIdQueryHandler(IGetEmployeeById employeeById, IMapper mapper)
            {
                this.employeeById = employeeById;
                this.mapper = mapper;
            }

            public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var employeeDto = await this.employeeById.ExecuteAsync(request.Id).ConfigureAwait(false);
                var employeeModel = mapper.Map<EmployeeModel>(employeeDto);
                return employeeModel;
            }
        }
    }
}