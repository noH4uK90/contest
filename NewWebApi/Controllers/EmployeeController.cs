using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace NewWebApi.Controllers;

public class EmployeeController : BaseController
{
    private readonly PassDbContext _passDbContext;

    public EmployeeController(PassDbContext passDbContext)
    {
        _passDbContext = passDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Employee>>> GetEmployees()
    {
        return await _passDbContext.Employees.ToArrayAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee([FromBody] Employee employee)
    {
        await _passDbContext.Employees.AddAsync(employee);
        await _passDbContext.SaveChangesAsync();

        return employee;
    }
}