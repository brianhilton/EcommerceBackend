using EcommerceBackend.Common.Dto;
using EcommerceBackend.Common.RequestResponse;
using EcommerceBackend.Data.Models;
using EcommerceBackend.Data.Repository;
using EcommerceBackend.Logic.Interfaces;

namespace EcommerceBackend.Logic.Services;

public class UserService: IUserService
{
    private readonly IGenericRepository<User> _repository;
    private readonly ITokenService _tokenService;

    public UserService(IGenericRepository<User> repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<UserDto?> CreateUser(User newUser)
    {
        var exists = _repository.GetAll().Any(u => u.Username == newUser.Username);

        if (exists || string.IsNullOrEmpty(newUser.Username) || string.IsNullOrEmpty(newUser.Password)) return null;
        
        newUser.JoinDate = DateTime.Now.ToUniversalTime();

        _repository.Insert(newUser);
        _repository.SaveChanges();

        return new UserDto() { Id = newUser.Id, Username = newUser.Username, JoinDate = newUser.JoinDate.Value, ProfileImageUrl = newUser.ProfileImageUrl};
    }

    public async Task<UserDto?> GetUserById(int id)
    {
        var user = _repository.Single(id);
        return user == null ? null : new UserDto() { Id = user.Id, Username = user.Username, JoinDate = user.JoinDate.Value, ProfileImageUrl = user.ProfileImageUrl};
    }

    public async Task<LoginResponse?> Login(string username, string password)
    {
        var user = _repository.GetAll().Single(u => u.Username == username);

        if (user == null) return null;

        var valid = user.Password == password;

        if (!valid) return null;

        var userDto = new UserDto() { Username = user.Username, Id = user.Id, JoinDate = user.JoinDate.Value, ProfileImageUrl = user.ProfileImageUrl};

        var token = _tokenService.GenerateAccessToken(userDto);

        return new LoginResponse() { User = userDto, AccessToken = token };
    }
}