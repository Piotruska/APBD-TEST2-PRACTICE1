using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Repositories;

public interface IReservationsRepository
{
    public Task<List<Reservation>> GetCusotmerReservationsAsync(int idCustomer);
    
    public Task<Reservation?> GetCusotmerActiveReservationsAsync(int idCustomer);
    public Task<int> AddReservationAsync(Reservation reservation);

    public Task ConnectBoatToReservation(IEnumerable<Sailboat> listofBoats,Reservation reservation);
    
}