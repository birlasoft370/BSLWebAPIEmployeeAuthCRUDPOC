using DataEntity;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using RepositoryHandler.MsSql.EF;
using System.Linq;

namespace EmployeeWebAPI.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Employee> Add(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Delete(int id)
        {
            Employee employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            return await context.Employees.FindAsync(Id);
        }

        public async Task<Employee> Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return employeeChanges;
        }
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext context;

        public UsersRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            User usermodel = null;

            UserDTO user = await context.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefaultAsync();
            if (user == null)
            {
                usermodel = new User { Id = 0, Username = "", Password = "" };
            }
            else
            {
                usermodel = new User { Id = user.Id, Username = user.UserName, Password = user.Password };
            }
            return usermodel;
        }
    }
}
