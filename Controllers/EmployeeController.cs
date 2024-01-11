using It_disain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    // GET: api/Employee
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmployees()
    {
        // Kood andmebaasist kõigi töötajate pärimiseks
        return new List<Employee>();
    }

    // GET: api/Employee/5
    [HttpGet("{id}")]
    public ActionResult<Employee> GetEmployee(int id)
    {
        // Kood konkreetse töötaja pärimiseks
        return new Employee();
    }

    // POST: api/Employee
    [HttpPost]
    public IActionResult CreateEmployee([FromBody] Employee employee)
    {
        // Kood uue töötaja lisamiseks andmebaasi
        return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
    }

    // PUT: api/Employee/5
    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
    {
        // Kood olemasoleva töötaja uuendamiseks
        return NoContent();
    }

    // DELETE: api/Employee/5
    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        // Kood töötaja kustutamiseks andmebaasist
        return NoContent();
    }
}
