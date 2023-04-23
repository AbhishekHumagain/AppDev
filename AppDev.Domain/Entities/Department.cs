using AppDev.Domain.Shared;

namespace AppDev.Domain.Entities
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
