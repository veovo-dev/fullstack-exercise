namespace FlightsData.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("flight")]
    public class Flight
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("flight_number")]
        public string FlightNumber { get; set; } = null!;

        [Column("airline")]
        public string? Airline { get; set; }

        [Column("origin")]
        public string? Origin { get; set; }

        [Column("destination")]
        public string? Destination { get; set; }

        [Column("vector")]
        public string? Vector { get; set; }

        [Column("aircraft_type")]
        public string? AircraftType { get; set; }

        [Column("stand")]
        public string? Stand { get; set; }

        [Column("gate")]
        public string? Gate { get; set; }

        [Column("terminal")]
        public string? Terminal { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("dt_scheduled")]
        public DateTime DtScheduled { get; set; }

        [Column("dt_estimated")]
        public DateTime? DtEstimated { get; set; }

        [Column("dt_actual")]
        public DateTime? DtActual { get; set; }

        [Column("linked_flight")]
        public string? LinkedFlight { get; set; }

        [Column("dt_created_at")]
        public DateTime DtCreatedAt { get; set; }
    }
}
