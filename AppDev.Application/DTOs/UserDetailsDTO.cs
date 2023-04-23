namespace AppDev.Application.DTOs;

public class UserDetailsDTO
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public bool IsEmailConfirmed { get; set; }
}