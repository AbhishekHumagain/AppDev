using System.ComponentModel.DataAnnotations;

namespace AppDev.Application.DTOs;

public class UserLoginRequestDTO
{
    [Required(ErrorMessage = "User Name is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}