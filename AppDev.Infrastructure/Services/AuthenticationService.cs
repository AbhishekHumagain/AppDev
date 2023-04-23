using AppDev.Application.Common.Interface;
using AppDev.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppDev.Infrastructure.Services;

public class AuthenticationService : IAuthentication
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<ResponseDTO> Register(UserRegisterRequestDto model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return new ResponseDTO { Status = "Error", Message = "User already exists!" };

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return
                new ResponseDTO
                    { Status = "Error", Message = "User creation failed! Please check user details and try again." };

        return new ResponseDTO { Status = "Success", Message = "User created successfully!" };
    }

    public async Task<ResponseDTO> Login(UserLoginRequestDTO model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
    
        if (result.Succeeded)
        {
            return new ResponseDTO()
            {
                Message = "User logged in!",
                Status = "Success"
            };
        }

        return new ResponseDTO()
        {
            Message = "User login failed! Please check user details and try again.!",
            Status = "Error"
        };

    }

    public async Task<IEnumerable<UserDetailsDTO>> GetUserDetails()
    {
        var users = await _userManager.Users.Select(x => new
        {
            x.Email,
            x.UserName,
            x.EmailConfirmed
        }).ToListAsync();

        //either
        var userDetails = from userData in users
            select new UserDetailsDTO()
            {
                Email = userData.Email,
                UserName = userData.UserName,
                IsEmailConfirmed = userData.EmailConfirmed
            };

        //OR
        var userDatas = new List<UserDetailsDTO>();
        foreach (var item in users)
        {
            userDatas.Add(new UserDetailsDTO()
            {
                Email = item.Email,
                UserName = item.UserName,
                IsEmailConfirmed = item.EmailConfirmed
            });
        }

        return userDatas;
    }
}