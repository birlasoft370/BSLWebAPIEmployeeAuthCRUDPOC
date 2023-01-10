using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class UpdateEmployee : IUpdateEmployee
    {
        private readonly IEmployeeOperation employeeOperations;

        public UpdateEmployee(IEmployeeOperation employeeOperatons)
        {
            this.employeeOperations = employeeOperatons;
        }

        public async Task<EmployeeDTO> ExecuteAsync(EmployeeDTO employee)
        {
            var result = await employeeOperations.Update(employee).ConfigureAwait(false);

            return result;
        }
    }
}
