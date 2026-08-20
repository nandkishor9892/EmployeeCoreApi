using Microsoft.EntityFrameworkCore;

namespace EmployeeNetCoreApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EmployeeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DbConnection"));
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
