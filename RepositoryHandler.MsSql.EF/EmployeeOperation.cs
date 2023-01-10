using DataEntity;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace RepositoryHandler.MsSql.EF
{
    public class EmployeeOperation : IEmployeeOperation
    {
        private readonly ApplicationDbContext applicationDbContext;

        public EmployeeOperation(ApplicationDbContext employeeDbContext)
        {
            this.applicationDbContext = employeeDbContext ?? throw new ArgumentNullException(nameof(employeeDbContext));
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get => this.applicationDbContext;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployee()
        {

            var result = await (ApplicationDbContext.Employee.ToListAsync()).ConfigureAwait(false);

            return result;

            /*
            var employees = new List<EmployeeDTO>
            {
                new EmployeeDTO() { Id = 1, Name = "Mary", Department = "HR", Address = "mary@test.com" },
                new EmployeeDTO() { Id = 2, Name = "John", Department = "IT", Address = "john@test.com" },
                new EmployeeDTO() { Id = 3, Name = "Sam", Department = "IT", Address = "sam@test.com" }
            };

            return await Task.FromResult(employees);*/
        }

        public async Task<EmployeeDTO> GetEmployeeById(int employeeId)
        {
            return await ApplicationDbContext.Employee.FindAsync(employeeId);
        }

        public async Task<EmployeeDTO> Add(EmployeeDTO employee)
        {
            await ApplicationDbContext.Employee.AddAsync(employee);
            await ApplicationDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO employeeChanges)
        {
            var employee = ApplicationDbContext.Employee.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await ApplicationDbContext.SaveChangesAsync();
            return employeeChanges;
        }

        public async Task DeleteEmployeeByIdAsync(int id)
        {
            EmployeeDTO employee = await ApplicationDbContext.Employee.FindAsync(id);
            if (employee != null)
            {
                ApplicationDbContext.Employee.Remove(employee);
                await ApplicationDbContext.SaveChangesAsync();
            }
        }
    }
}
