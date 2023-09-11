using Incidents.Application.Common.Interfaces;
namespace Incidents.Infrastructure.Service
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
