using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class UpdateDepartment : IUpdateDepartment
    {
        private readonly IDepartmentOperation departmentOperations;

        public UpdateDepartment(IDepartmentOperation DepartmentOperatons)
        {
            this.departmentOperations = DepartmentOperatons;
        }

        public async Task<DepartmentDTO> ExecuteAsync(DepartmentDTO Department)
        {
            var result = await departmentOperations.Update(Department).ConfigureAwait(false);

            return result;
        }
    }
}
