using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGetDepartments
    {
        Task<IEnumerable<DepartmentDTO>> ExecuteAsync();
    }
}
