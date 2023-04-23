using AppDev.Application.Common.Interface;
using AppDev.Domain.Entities;
using AppDev.Application.DTOs;

namespace AppDev.Infrastructure.Services
{
    public class EmployeeDetails : IEmployeeDetails
    {
        private readonly IApplicationDbContext _dbContext;
        public EmployeeDetails(IApplicationDbContext dBContext)
        {
            _dbContext = dBContext;
        }


        public Task<List<EmployeeResponseDTO>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeResponseDTO> AddEmployeeDetails(EmployeeRequestDTO employee)
        {
            var employeeDetails = new Employee()
            {
                JoinDate = employee.JoinDate,
                Designation = employee.Designation,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId
            };
            await _dbContext.Employee.AddAsync(employeeDetails);
            await _dbContext.SaveChangesAsync(default(CancellationToken));
            
            var result = new EmployeeResponseDTO()
            {
                Designation = employeeDetails.Designation,
                Salary = employeeDetails.Salary
            };
            return result;
        }

        public Task<List<EmployeeResponseDTO>> GetAllUserAsync()
        {
            var data = (from empData in _dbContext.Employee
                join depart in _dbContext.Department
                    on empData.DepartmentId equals depart.Id
                select new EmployeeResponseDTO()
                {
                    DepartmentName = depart.Name,
                    Designation = empData.Designation,
                    Salary = empData.Salary
                }).ToList();
                
            
            return Task.FromResult(data);
        }

       
    }
}
