using MediatR;

namespace DomainModel
{
    public class AddEmployeeRequest : IRequest<AddEmployeeResponse>
    {
        public AddEmployeeRequest()
        {
            EmployeeModel = new();
        }
        public EmployeeModel EmployeeModel { get; set; }
    }
}
