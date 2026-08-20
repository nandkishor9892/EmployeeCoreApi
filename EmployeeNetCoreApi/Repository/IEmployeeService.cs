namespace EmployeeNetCoreApi.Repository
{
    public interface IEmployeeService
    {
        Task<int> SaveEmployee(Employee employee);
        Task<int> UpdateEmployee(Employee employee);

        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Employee>> GetEmployeeById(int id);

        Task<int> DeleteEmployee(int id);
    }
}
