using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDepartmentOperation
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartment();
        Task<DepartmentDTO> GetDepartmentById(int departmentId);
        Task<DepartmentDTO> Add(DepartmentDTO department);
        Task<DepartmentDTO> Update(DepartmentDTO departmentChanges);
        Task DeleteDepartmentByIdAsync(int departmentId);
    }
}
