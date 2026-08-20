using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeNetCoreApi;
using EmployeeNetCoreApi.Data;
using EmployeeNetCoreApi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _context;

        public EmployeesController(IEmployeeService context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var response =  await _context.GetEmployees();
            if (response == null)
            {
                return null;
            }
            return response;
        }

        // GET: api'/Employees/5
        [HttpGet("GetEmployeeById")]
        public async Task<Employee> GetEmployeeById(int id)
        {

            var employee = await _context.GetEmployeeById(id);

            if (employee == null)
            {
                return null;
            }

            return employee.FirstOrDefault();
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
              var result =  await _context.UpdateEmployee(employee);
                if(result >0 )
                {
                    return Ok(result);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> SaveEmployee(Employee employee)
        {
            var result = await _context.SaveEmployee(employee);
            if(result>0)
            {
                return Ok(result);
            }
            return BadRequest(); ;
        }

        // DELETE: api/Employees/5
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.DeleteEmployee(id);
            if (employee > 0)
            {
                return Ok(id);
            }
            return NoContent();
        }
        
    }
}
