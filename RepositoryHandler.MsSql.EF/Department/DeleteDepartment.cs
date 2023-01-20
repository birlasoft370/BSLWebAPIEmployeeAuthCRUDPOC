using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class DeleteDepartment : IDeleteDepartment
    {
        private readonly IDepartmentOperation departmentOperation;

        public DeleteDepartment(IDepartmentOperation departmentOperation)
        {
            this.departmentOperation = departmentOperation;
        }

        public async Task ExecuteAsync(int DepartmentId)
        {
            await departmentOperation.DeleteDepartmentByIdAsync(DepartmentId).ConfigureAwait(false);
        }
    }
}
