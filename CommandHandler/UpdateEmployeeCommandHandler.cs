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
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
    {
        private readonly IUpdateEmployee updateEmployee;
        private readonly IMapper mapper;

        public UpdateEmployeeCommandHandler(IUpdateEmployee updateEmployee, IMapper mapper)
        {
            this.updateEmployee = updateEmployee;
            this.mapper = mapper;
        }

        public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var EmployeeDto = mapper.Map<EmployeeDTO>(request.EmployeeModel);
            await this.updateEmployee.ExecuteAsync(EmployeeDto).ConfigureAwait(false);

            return new UpdateEmployeeResponse()
            {
                EmployeeModel = request.EmployeeModel
            };
        }
    }

}
