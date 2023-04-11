using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace NewWebApi.Controllers;

public class VisitController : BaseController
{
    private readonly PassDbContext _passDbContext;

    public VisitController(PassDbContext passDbContext)
    {
        _passDbContext = passDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Visit>>> GetVisits()
    {
        return await _passDbContext.Visits.ToArrayAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Visit>> PostVisit([FromBody] Visit visit)
    {
        await _passDbContext.Visits.AddAsync(visit);
        await _passDbContext.SaveChangesAsync();

        return visit;
    }
}