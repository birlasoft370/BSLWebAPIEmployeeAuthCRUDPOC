using DataEntity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryHandler.MsSql.EF
{
    public class GetEmployeeById : IGetEmployeeById
    {
        private readonly IEmployeeOperation employeeOperatons;

        public GetEmployeeById(IEmployeeOperation employeeOperatons)
        {
            this.employeeOperatons = employeeOperatons;
        }

        public async Task<EmployeeDTO> ExecuteAsync(int employeeId)
        {
            var result = await employeeOperatons.GetEmployeeById(employeeId).ConfigureAwait(false);

            return result;
        }
    }
}
