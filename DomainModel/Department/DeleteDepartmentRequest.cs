using MediatR;

namespace DomainModel
{
    public class DeleteDepartmentRequest: IRequest<DeleteDepartmentResponse>
    {
        public int DepartmentId { get; set; }
    }
}
