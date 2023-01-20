using DomainModel;
using MediatR;
using Repository;

namespace CommandHandler
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentRequest, DeleteDepartmentResponse>
    {
        private readonly IDeleteDepartment deleteDepartment;

        public DeleteDepartmentCommandHandler(IDeleteDepartment deleteDepartment)
        {
            this.deleteDepartment = deleteDepartment;
        }

        public async Task<DeleteDepartmentResponse> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            await this.deleteDepartment.ExecuteAsync(request.DepartmentId).ConfigureAwait(false);
            return new DeleteDepartmentResponse() { DepartmentId = request.DepartmentId };
        }
    }
}
