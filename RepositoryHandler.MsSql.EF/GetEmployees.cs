using DataEntity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryHandler.MsSql.EF
{
    public class GetEmployees : IGetEmployees
    {
        private readonly IEmployeeOperation employeeOperatons;

        public GetEmployees(IEmployeeOperation employeeOperatons)
        {
            this.employeeOperatons = employeeOperatons;
        }

        public async Task<IEnumerable<EmployeeDTO>> ExecuteAsync()
        {
            var result = await employeeOperatons.GetAllEmployee().ConfigureAwait(false);

            return result;
        }
    }
}
