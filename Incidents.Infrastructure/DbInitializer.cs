namespace Incidents.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(IncidentsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
