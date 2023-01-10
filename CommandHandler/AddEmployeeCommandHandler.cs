using AutoMapper;
using DataEntity;
using DomainModel;
using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandler
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IAddEmployee addEmployee;
        private readonly IMapper mapper;

        public AddEmployeeCommandHandler(IAddEmployee addEmployee, IMapper mapper)
        {
            this.addEmployee = addEmployee;
            this.mapper = mapper;
        }

        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employeeDto = mapper.Map<EmployeeDTO>(request.EmployeeModel);
            var result = await this.addEmployee.ExecuteAsync(employeeDto).ConfigureAwait(false);
            var entity = mapper.Map<EmployeeModel>(result);

            return new AddEmployeeResponse()
            {
                EmployeeModel = entity
            };
        }
    }
}
