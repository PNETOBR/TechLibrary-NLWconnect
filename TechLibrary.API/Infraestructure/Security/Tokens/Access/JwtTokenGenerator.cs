using Microsoft.IdentityModel.Tokens;
using TechLibrary.API.Domain.Entities;

namespace TechLibrary.API.Infraestructure.Security.Tokens.Access;

public class JwtTokenGenerator
{
    public string Generate(User user)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //Expires = DateTime.UtcNow.AddHours(1),
        };
    }
}
