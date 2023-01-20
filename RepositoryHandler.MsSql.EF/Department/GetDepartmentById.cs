using DataEntity;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class GetDepartmentById : IGetDepartmentById
    {
        private readonly IDepartmentOperation departmentOperatons;

        public GetDepartmentById(IDepartmentOperation departmentOperatons)
        {
            this.departmentOperatons = departmentOperatons;
        }

        public async Task<DepartmentDTO> ExecuteAsync(int departmentId)
        {
            return await departmentOperatons.GetDepartmentById(departmentId).ConfigureAwait(false);
        }
    }
}
