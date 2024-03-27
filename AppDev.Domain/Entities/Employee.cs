using System.ComponentModel.DataAnnotations.Schema;
using AppDev.Domain.Shared;

namespace AppDev.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime JoinDate { get; set; }
        public string? Designation { get; set; }
        public float Salary { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
