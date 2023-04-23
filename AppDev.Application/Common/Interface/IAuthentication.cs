using AppDev.Application.DTOs;

namespace AppDev.Application.Common.Interface;

public interface IAuthentication
{
    Task<ResponseDTO> Register(UserRegisterRequestDto model);
    Task<ResponseDTO> Login(UserLoginRequestDTO model);
    Task<IEnumerable<UserDetailsDTO>> GetUserDetails();
}