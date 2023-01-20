using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class AddDepartment : IAddDepartment
    {
        private readonly IDepartmentOperation departmentOperations;

        public AddDepartment(IDepartmentOperation departmentOperatons)
        {
            this.departmentOperations = departmentOperatons;
        }

        public async Task<DepartmentDTO> ExecuteAsync(DepartmentDTO Department)
        {
            var result = await departmentOperations.Add(Department).ConfigureAwait(false);

            return result;
        }
    }
}
