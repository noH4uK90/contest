using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Entities;

namespace NewWebApi.Controllers;

public class UserController : BaseController
{
    private readonly PassDbContext _passDbContext;

    public UserController(PassDbContext passDbContext)
    {
        _passDbContext = passDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<User>>> GetUsers()
    {
        return await _passDbContext.Users.ToArrayAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser([FromBody] User user)
    {
        await _passDbContext.Users.AddAsync(user);
        await _passDbContext.SaveChangesAsync();

        return user;
    }
}