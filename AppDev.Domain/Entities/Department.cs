using AppDev.Domain.Shared;

namespace AppDev.Domain.Entities
{
    public class Department : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
