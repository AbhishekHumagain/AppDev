using AppDev.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDev.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<Department> Department { get; set; }
        DbSet<SalaryOrBonus> SalaryOrBonus { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
