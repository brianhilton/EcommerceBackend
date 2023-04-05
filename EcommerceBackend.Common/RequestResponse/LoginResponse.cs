using EcommerceBackend.Common.Dto;

namespace EcommerceBackend.Common.RequestResponse;

public class LoginResponse
{
    public string AccessToken { get; set; }
    public UserDto User { get; set; }
}