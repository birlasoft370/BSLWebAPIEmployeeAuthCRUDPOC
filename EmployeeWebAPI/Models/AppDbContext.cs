using DomainModel.Department;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection"));
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DepartmentModel> Department { get; set; }
        

        //protected AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //}
        //public DbSet<Employee> Employees { get; set; }
    }
}
