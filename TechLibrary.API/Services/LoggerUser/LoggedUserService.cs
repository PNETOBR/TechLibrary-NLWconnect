using System.IdentityModel.Tokens.Jwt;
using TechLibrary.API.Domain.Entities;
using TechLibrary.API.Infraestructure.DataAccess;

namespace TechLibrary.API.Services.LoggerUser;

public class LoggedUserService
{
    private readonly HttpContext _httpContext;
    public LoggedUserService(HttpContext httpcontext)
    {
        _httpContext = httpcontext;
    }

    public User User()
    {
        var authentication = _httpContext.Request.Headers.Authorization.ToString();
        var token = authentication["Bearer ".Length..].Trim();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var idenfifier = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;

        var userId = Guid.Parse(idenfifier);

        var dbContext = new TechLibraryDbContext();

        return dbContext.Users.First(user => user.Id == userId);
    }

}
