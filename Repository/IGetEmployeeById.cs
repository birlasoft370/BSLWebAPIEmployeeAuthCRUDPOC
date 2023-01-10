using DataEntity;

namespace Repository
{
    public interface IGetEmployeeById
    {
        Task<EmployeeDTO> ExecuteAsync(int employeeId);
    }
}
