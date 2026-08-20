
using EmployeeNetCoreApi.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EmployeeNetCoreApi.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;
        public EmployeeService(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployeeById(int id)
        {   var EmpId = new SqlParameter("@EmpId", id);
            var result = await Task.Run(() =>  _context.Employees.FromSqlRaw("Exec GetEmployeesById @EmpId", EmpId).ToListAsync());
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await Task.Run(() => _context.Employees.FromSqlRaw("Exec GetEmployees").ToListAsync());
            return result;
        }

        public async Task<int> SaveEmployee(Employee employee)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@EmpName", employee.EmpName));
            param.Add(new SqlParameter("@Salary", employee.Salary));
            param.Add(new SqlParameter("@Address", employee.Address));
            int result = await Task.Run(() => _context.Database.ExecuteSqlRawAsync("Exec SaveEmployee @EmpName , @Salary ,@Address " ,param.ToArray()));
            
            return result;
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            var param = new List<SqlParameter>();

            param.Add(new SqlParameter("@EmpId", employee.EmpId));
            param.Add(new SqlParameter("@EmpName", employee.EmpName));
            param.Add(new SqlParameter("@Salary", employee.Salary));
            param.Add(new SqlParameter("@Address", employee.Address));

            var result = await Task.Run(() => _context.Database.ExecuteSqlRawAsync("Exec UpdateEmployee @EmpId , @EmpName , @Salary , @Address ", param.ToArray()));
            return result;
        }
        public async Task<int> DeleteEmployee(int id)
        {
            var param = new SqlParameter("@EmpId", id);
            var result = await Task.Run(() => _context.Database.ExecuteSqlRawAsync("Exec DeleteEmployee @EmpId", param));
            return result;
        }
    }
}
