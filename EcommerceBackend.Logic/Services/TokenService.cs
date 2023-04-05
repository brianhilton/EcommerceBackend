using System.Buffers.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcommerceBackend.Common.Dto;
using EcommerceBackend.Logic.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceBackend.Logic.Services;

public class TokenService : ITokenService
{
    public string GenerateAccessToken(UserDto forUser)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes("-----BEGIN PUBLIC KEY-----MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgHOEpBDCBQmSGk48jDQOS4u/NLpy vvNnIZH3jUOn6VRZkqvKUvu9GtbilslpWXItxkclm8YcVvXOQ+ZZkM5vCng7TJz3 jk+qKlIMT3FQR9HYq0tcGLu7U3oJkBQidOpQiHqnVFnwrVyD9YVoxqFD/x27dm86 BDXK/CzA5jP6Oe/7AgMBAAE= -----END PUBLIC KEY-----");
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", forUser.Id!.ToString()) }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken(UserDto forUser)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, string>? Validate(string? token, TokenType tokenType)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("secret");
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            var claims = jwtToken.Claims.ToDictionary(k => k.Type, v => v.Value);
            
            // return account id from JWT token if validation successful
            return claims;
        }
        catch
        {
            // return null if validation fails
            return null;
        }
    }
}