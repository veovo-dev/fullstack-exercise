namespace DataProducerService.Biz
{
    using FlightsData;
    using FlightsData.Models;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class FlightProducerService : BackgroundService
    {
        private static readonly string[] Airlines = ["FR", "BA", "LH", "AF", "KL", "EI", "U2", "W6"];
        private static readonly string[] Airports = ["DUB", "LHR", "CDG", "AMS", "FRA", "MAD", "FCO", "BER"];
        private static readonly string[] AircraftTypes = ["B738", "A320", "A321", "B77W", "A20N", "B38M"];
        private static readonly string[] Statuses = ["Scheduled", "Boarding", "Departed", "Arrived", "Cancelled"];
        private static readonly string[] Vectors = ["A", "D"];
        private static readonly string[] Gates = ["A1", "A2", "B1", "B2", "C1", "C2", "D1", "D2"];
        private static readonly string[] Terminals = ["T1", "T2"];

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<FlightProducerService> _logger;
        private readonly Random _random = new();

        public FlightProducerService(IServiceScopeFactory scopeFactory, ILogger<FlightProducerService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Flight producer started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<FlightsDbContext>();

                var flight = GenerateFlight();
                db.Flights.Add(flight);
                await db.SaveChangesAsync(stoppingToken);

                _logger.LogInformation("Produced flight {FlightNumber} ({Vector}) scheduled at {DtScheduled}",
                    flight.FlightNumber, flight.Vector, flight.DtScheduled);

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        private Flight GenerateFlight()
        {
            var airline = Airlines[_random.Next(Airlines.Length)];
            var number = _random.Next(100, 9999);
            var vector = Vectors[_random.Next(Vectors.Length)];

            return new Flight
            {
                FlightNumber = $"{airline}{number}",
                Airline = airline,
                Origin = vector == "A" ? Airports[_random.Next(Airports.Length)] : "DUB",
                Destination = vector == "D" ? Airports[_random.Next(Airports.Length)] : "DUB",
                Vector = vector,
                AircraftType = AircraftTypes[_random.Next(AircraftTypes.Length)],
                Stand = $"{_random.Next(1, 50)}",
                Gate = Gates[_random.Next(Gates.Length)],
                Terminal = Terminals[_random.Next(Terminals.Length)],
                Status = Statuses[0],
                LinkedFlight = null,
                DtScheduled = DateTime.UtcNow.AddHours(_random.Next(1, 48)),
                DtCreatedAt = DateTime.UtcNow,
            };
        }
    }
}
