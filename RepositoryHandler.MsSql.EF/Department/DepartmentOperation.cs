using DataEntity;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class DepartmentOperation : IDepartmentOperation
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DepartmentOperation(ApplicationDbContext employeeDbContext)
        {
            this.applicationDbContext = employeeDbContext ?? throw new ArgumentNullException(nameof(employeeDbContext));
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get => this.applicationDbContext;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartment()
        {

            var result = await (ApplicationDbContext.Department.ToListAsync()).ConfigureAwait(false);

            return result;
        }

        public async Task<DepartmentDTO> GetDepartmentById(int DepartmentId)
        {
            return await ApplicationDbContext.Department.FindAsync(DepartmentId);
        }

        public async Task<DepartmentDTO> Add(DepartmentDTO Department)
        {
            await ApplicationDbContext.Department.AddAsync(Department);
            await ApplicationDbContext.SaveChangesAsync();
            return Department;
        }

        public async Task<DepartmentDTO> Update(DepartmentDTO DepartmentChanges)
        {
            var Department = ApplicationDbContext.Department.Attach(DepartmentChanges);
            Department.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await ApplicationDbContext.SaveChangesAsync();
            return DepartmentChanges;
        }

        public async Task DeleteDepartmentByIdAsync(int id)
        {
            DepartmentDTO Department = await ApplicationDbContext.Department.FindAsync(id);
            if (Department != null)
            {
                ApplicationDbContext.Department.Remove(Department);
                await ApplicationDbContext.SaveChangesAsync();
            }
        }

    }
}
