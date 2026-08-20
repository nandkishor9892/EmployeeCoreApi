using System.ComponentModel.DataAnnotations;

namespace EmployeeNetCoreApi
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public long  Salary { get; set; }
        public string Address { get; set; }
    }
}
