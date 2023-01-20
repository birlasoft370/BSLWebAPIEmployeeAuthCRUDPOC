using DataEntity;

namespace Repository
{
    public interface IGetDepartmentById
    {
        Task<DepartmentDTO> ExecuteAsync(int employeeId);
    }
}
