using DomainModel.Department;

namespace DomainModel
{
    public class AddDepartmentResponse
    {
        public AddDepartmentResponse()
        {
            DepartmentModel = new();
        }
        public DepartmentModel DepartmentModel { get; set; }
    }
}
