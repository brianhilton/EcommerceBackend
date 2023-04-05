using EcommerceBackend.Common.Dto;
using EcommerceBackend.Common.RequestResponse;
using EcommerceBackend.Data.Models;
using EcommerceBackend.Data.Repository;

namespace EcommerceBackend.Logic.Interfaces;

public interface IUserService
{
    Task<UserDto?> CreateUser(User newUser);
    Task<UserDto?> GetUserById(int id);
    Task<LoginResponse?> Login(string username, string password);
}