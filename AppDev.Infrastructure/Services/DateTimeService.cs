using AppDev.Application.Common.Interface;

namespace AppDev.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
