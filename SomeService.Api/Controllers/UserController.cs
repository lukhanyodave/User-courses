using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using Skunkworks.Domain.Entities;
using Skunkworks.Shared;

using SomeService.Api.Data;

namespace SomeService.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class UserController : ControllerBase
{

    private DemoDbContext _dbContext;
    private readonly ILogger<UserController> _logger;


    public UserController(DemoDbContext dbContext, ILogger<UserController> logger)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetLogin")]
    public async Task<LoggedInUser> Get()
    {
        var emails = string.Join(",", HttpContext.User.Claims
            .Where(c => c.Type == "emails")
            .Select(c => c.Value));
        var user = await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == emails);
        if (user == null)
        {
            user = new User()
            {
                Email = emails,
                IsTeacher = false
            };
            _dbContext.Set<User>().Add(user);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogInformation("User {Email} already exists", emails);
        }
        return new LoggedInUser()
        {
            Id = user?.Id ?? Guid.Empty,
            Email = emails,
            Roles = user != null && user.IsTeacher ? ["Teacher"] : ["Student"]
        };
        
    }
}
