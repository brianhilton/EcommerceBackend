using System.Security.Claims;
using EcommerceBackend.Common.Dto;

namespace EcommerceBackend.Logic.Interfaces;

public enum TokenType
{
    Access,
    Refresh
}

public interface ITokenService
{
    string GenerateAccessToken(UserDto forUser);
    string GenerateRefreshToken(UserDto forUser);
    Dictionary<string, string>? Validate(string token, TokenType tokenType);
}