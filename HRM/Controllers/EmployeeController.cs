using HRM.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRMExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Department = "HR" },
            new Employee { Id = 2, Name = "Jane Smith", Department = "IT" },
            // Thêm các nhân viên khác tại đây
        };

        // GET: api/employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employees;
        }

        // GET: api/employee/1
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        // POST: api/employee
        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT: api/employee/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee updatedEmployee)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            return NoContent();
        }

        // DELETE: api/employee/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _employees.Remove(employee);
            return NoContent();
        }

        // GET: api/employee/search?name=John
        [HttpGet("search")]
        public ActionResult<IEnumerable<Employee>> Search(string name)
        {
            var employees = _employees.Where(e => e.Name.Contains(name));
            return Ok(employees);
        }
    }
}
