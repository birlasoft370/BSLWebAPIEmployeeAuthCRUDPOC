using DataEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RepositoryHandler.MsSql.EF
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection"));
        }

        public DbSet<EmployeeDTO> Employee { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<DepartmentDTO> Department { get; set; }

    }
}
