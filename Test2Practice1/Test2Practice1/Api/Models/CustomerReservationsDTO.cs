using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Models;

public class CustomerReservationsDTO
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public List<Reservation> Reservations { get; set; }
}