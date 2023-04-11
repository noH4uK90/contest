using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace NewWebApi.Controllers;

public class VisitInfoController : BaseController
{
    private readonly PassDbContext _passDbContext;

    public VisitInfoController(PassDbContext passDbContext)
    {
        _passDbContext = passDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<VisitInfo>>> GetVisitInfos()
    {
        return await _passDbContext.VisitInfos.ToArrayAsync();
    }

    [HttpPost]
    public async Task<ActionResult<VisitInfo>> PostVisitInfo([FromBody] VisitInfo visitInfo)
    {
        await _passDbContext.VisitInfos.AddAsync(visitInfo);
        await _passDbContext.SaveChangesAsync();

        return visitInfo;
    }
}