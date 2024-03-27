using AppDev.Domain.Entities;
using AppDev.Application.DTOs;

namespace AppDev.Application.Common.Interface
{
    public interface IEmployeeDetails
    {
        Task<List<EmployeeResponseDTO>> GetAllUserAsync();
        Task<EmployeeResponseDTO> AddEmployeeDetails(EmployeeRequestDto employee);
    }
}
