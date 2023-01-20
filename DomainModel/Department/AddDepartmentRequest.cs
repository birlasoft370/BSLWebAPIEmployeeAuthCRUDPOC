using DomainModel.Department;
using MediatR;

namespace DomainModel
{
    public class AddDepartmentRequest : IRequest<AddDepartmentResponse>
    {
        public AddDepartmentRequest()
        {
            DepartmentModel = new();
        }
        public DepartmentModel DepartmentModel { get; set; }
    }
}
