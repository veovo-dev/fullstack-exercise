namespace DataProducerService
{
    using DataProducerService.Biz;
    using FlightsData;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddSerilog(config => config.ReadFrom.Configuration(builder.Configuration));

            builder.Services.AddDbContext<FlightsDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("FlightsDb")));

            builder.Services.AddHostedService<FlightProducerService>();

            var host = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<FlightsDbContext>();
                db.Database.EnsureCreated();
            }

            host.Run();
        }
    }
}
