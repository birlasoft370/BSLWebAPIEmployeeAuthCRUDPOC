using DomainModel.Department;

namespace DomainModel
{
    public class UpdateDepartmentResponse
    {
        public UpdateDepartmentResponse()
        {
            DepartmentModel = new();
        }

        public DepartmentModel DepartmentModel { get; set; }
    }
}
