using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace NewWebApi.Controllers;

public class UserVisitController : BaseController
{
    private readonly PassDbContext _passDbContext;

    public UserVisitController(PassDbContext passDbContext)
    {
        _passDbContext = passDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<UserVisit>>> GetUserVisits()
    {
        return await _passDbContext.UserVisits.ToArrayAsync();
    }

    [HttpPost]
    public async Task<ActionResult<UserVisit>> PostUserVisit([FromBody] UserVisit userVisit)
    {
        await _passDbContext.UserVisits.AddAsync(userVisit);
        await _passDbContext.SaveChangesAsync();

        return userVisit;
    }
}