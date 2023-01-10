using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGetEmployees
    {
        Task<IEnumerable<EmployeeDTO>> ExecuteAsync();
    }
}
