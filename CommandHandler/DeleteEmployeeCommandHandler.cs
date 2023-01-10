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
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
    {
        private readonly IDeleteEmployee deleteEmployee;

        public DeleteEmployeeCommandHandler(IDeleteEmployee deleteEmployee)
        {
            this.deleteEmployee = deleteEmployee;
        }

        public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            await this.deleteEmployee.ExecuteAsync(request.EmployeeId).ConfigureAwait(false);
            return new DeleteEmployeeResponse() { EmployeeId = request.EmployeeId };
        }
    }
}
