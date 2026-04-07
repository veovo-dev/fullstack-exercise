namespace FlightsData
{
    using FlightsData.Models;
    using Microsoft.EntityFrameworkCore;

    public class FlightsDbContext : DbContext
    {
        public FlightsDbContext(DbContextOptions<FlightsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; } = null!;
    }
}
