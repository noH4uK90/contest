using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace NewWebApi.Controllers;

public class DepartmentController : BaseController
{
    private readonly PassDbContext _passDbContext;

    public DepartmentController(PassDbContext passDbContext)
    {
        _passDbContext = passDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Department>>> GetDepartments()
    {
        return await _passDbContext.Departments.ToArrayAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Department>> PostDepartment([FromBody] Department department)
    {
        await _passDbContext.Departments.AddAsync(department);
        await _passDbContext.SaveChangesAsync();

        return department;
    }
}