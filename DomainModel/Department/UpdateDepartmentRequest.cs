using DomainModel.Department;
using MediatR;

namespace DomainModel
{
    public class UpdateDepartmentRequest : IRequest<UpdateDepartmentResponse>
    {
        public UpdateDepartmentRequest()
        {
            DepartmentModel = new();
        }

        public DepartmentModel DepartmentModel { get; set; }

    }
}
