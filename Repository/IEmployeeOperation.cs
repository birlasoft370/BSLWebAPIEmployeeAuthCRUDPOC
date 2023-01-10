using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEmployeeOperation
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployee();
        Task<EmployeeDTO> GetEmployeeById(int employeeId);
        Task<EmployeeDTO> Add(EmployeeDTO employee);
        Task<EmployeeDTO> Update(EmployeeDTO employeeChanges);
        Task DeleteEmployeeByIdAsync(int employeeId);
    }
}
