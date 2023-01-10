using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryHandler.MsSql.EF
{
    public class DeleteEmployee : IDeleteEmployee
    {
        private readonly IEmployeeOperation EmployeeOperation;

        public DeleteEmployee(IEmployeeOperation EmployeeOperation)
        {
            this.EmployeeOperation = EmployeeOperation;
        }

        public async Task ExecuteAsync(int employeeId)
        {
            await EmployeeOperation.DeleteEmployeeByIdAsync(employeeId).ConfigureAwait(false);
        }
    }
}
