using AppDev.Application.Common.Interface;
using AppDev.Application.DTOs;
using AppDev.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppDev.WebAPI.Controllers;

[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthentication _authenticationManager;

    public AuthenticateController(IAuthentication authenticationManager)
    {
        _authenticationManager = authenticationManager;
    }

    [HttpPost]
    [Route("/api/authenticate/register")]
    public async Task<ResponseDTO> Register([FromBody] UserRegisterRequestDto model)
    {
        var result = await _authenticationManager.Register(model);
        return result;
    }
    
    
    [HttpGet]
    [Route("/api/authenticate/getUserDetails")]
    public async Task<IEnumerable<UserDetailsDTO>> GetUserDetails()
    {
        var result = await _authenticationManager.GetUserDetails();
        return result;
    }
    
    [HttpPost]
    [AllowAnonymous]
    [Route("/api/authenticate/login")]
    public async Task<ResponseDTO> Login([FromBody]UserLoginRequestDTO user)
    {
        var result = await _authenticationManager.Login(user);
        return result;
    } 
}