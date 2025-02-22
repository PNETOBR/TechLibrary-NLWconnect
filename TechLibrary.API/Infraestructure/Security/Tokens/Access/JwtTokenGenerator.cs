using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechLibrary.API.Domain.Entities;

namespace TechLibrary.API.Infraestructure.Security.Tokens.Access;

public class JwtTokenGenerator
{
    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(60),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials =new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken); // essa função retorna o token gerado em string
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var signinkey = "hBpcLzQcTy9yDKe77r0SuD6tO5Oe0JF9";

        var symetricKey = Encoding.UTF8.GetBytes(signinkey);

        return new SymmetricSecurityKey(symetricKey);
    }
}
