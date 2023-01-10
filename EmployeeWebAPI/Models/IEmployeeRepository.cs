namespace EmployeeWebAPI.Models
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int Id);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employeeChanges);
        Task<Employee> Delete(int id);
    }

    public interface IUsersRepository
    {
        Task<User> ValidateUser(string username, string password);
    }
}
