using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class GetDepartments : IGetDepartments
    {
        private readonly IDepartmentOperation departmentOperatons;

        public GetDepartments(IDepartmentOperation departmentOperatons)
        {
            this.departmentOperatons = departmentOperatons;
        }

        public async Task<IEnumerable<DepartmentDTO>> ExecuteAsync()
        {
            var result = await departmentOperatons.GetAllDepartment().ConfigureAwait(false);

            return result;
        }
    }
}
