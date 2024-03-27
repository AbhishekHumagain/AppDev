using AppDev.Application.Common.Interface;
using AppDev.Domain.Entities;
using AppDev.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppDev.WebAPI.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDetails _employeeDetails;

        public EmployeeController(IEmployeeDetails employeeDetails)
        {
            _employeeDetails = employeeDetails;
        }

        [HttpGet]
        [Route("/api/employee/all-employee")]
        public async Task<List<EmployeeResponseDTO>> GetAllEmployeeDetails()
        {
            var data =  await _employeeDetails.GetAllUserAsync();
            return data;
        }

        [HttpPost]
        [Route("/api/employee/add-employee")]
        public async Task<EmployeeResponseDTO> AddEmployeeDetails(EmployeeRequestDto employee)
        {
            var data = await _employeeDetails.AddEmployeeDetails(employee);
            return data;
        }
    }
}
