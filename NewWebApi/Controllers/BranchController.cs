using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace NewWebApi.Controllers;

public class BranchController : BaseController
{
    private readonly PassDbContext _passDbContext;

    public BranchController(PassDbContext passDbContext)
    {
        _passDbContext = passDbContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<Branch>>> GetBranches()
    {
        return await _passDbContext.Branches.ToArrayAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Branch>> PostBranch([FromBody] Branch branch)
    {
        await _passDbContext.Branches.AddAsync(branch);
        await _passDbContext.SaveChangesAsync();

        return branch;
    }
}