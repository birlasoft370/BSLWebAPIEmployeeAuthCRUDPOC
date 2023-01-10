using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class AddEmployee : IAddEmployee
    {
        private readonly IEmployeeOperation employeeOperations;

        public AddEmployee(IEmployeeOperation employeeOperatons)
        {
            this.employeeOperations = employeeOperatons;
        }

        public async Task<EmployeeDTO> ExecuteAsync(EmployeeDTO employee)
        {
            var result = await employeeOperations.Add(employee).ConfigureAwait(false);

            return result;
        }
    }
}
