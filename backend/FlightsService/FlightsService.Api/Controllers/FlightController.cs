namespace FlightsService.Api.Controllers
{
    using FlightsData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly FlightsDbContext _dbContext;

        public FlightController(FlightsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _dbContext.Flights.OrderByDescending(f => f.DtScheduled).ToListAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight(long id)
        {
            var flight = await _dbContext.Flights.FindAsync(id);
            return flight is null ? NotFound() : Ok(flight);
        }
    }
}
