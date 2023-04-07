using EcommerceBackend.Common.Dto;
using EcommerceBackend.Common.RequestResponse;
using EcommerceBackend.Data.Models;
using EcommerceBackend.Logic.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserDto), 200)]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostUser(User newUser)
    {
        var user = await _userService.CreateUser(newUser);

        return user == null ? BadRequest("bad request") : Ok(user);
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(UserDto), 200)]
    [ProducesResponseType(typeof(string), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await _userService.GetUserById(userId);

        return user == null ? NotFound("not found") : Ok(user);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), 200)]
    [ProducesResponseType(typeof(string), 401)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostLogin(string username, string password)
    {
        var response = await _userService.Login(username, password);
        
        return response == null ? Unauthorized("unauthorized") : Ok(response);
    }
}