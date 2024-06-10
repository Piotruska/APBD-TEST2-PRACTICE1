using Microsoft.EntityFrameworkCore;
using Test2Practice1.DataBase.Context;
using Test2Practice1.Database.Entities;


namespace Test2Practice1.Api.Repositories;

public class ReservationsRepository : IReservationsRepository
{
    private readonly DataBaseCOntext _context;

    public ReservationsRepository(DataBaseCOntext context)
    {
        _context = context;
    }
    
    public async Task<List<Reservation>> GetCusotmerReservationsAsync(int idCustomer)
    {
        var responce = await _context.Reservations
            .Where(x => x.IdClient == idCustomer)
            .OrderByDescending(x=>x.DateTo)
            .ToListAsync();

        return responce;
    }

    public async Task<Reservation?> GetCusotmerActiveReservationsAsync(int idCustomer)
    {
        return await _context.Reservations
            .Where(x => x.IdClient == idCustomer)
            .Where(x => x.Fulfilled)
            .FirstOrDefaultAsync();
    }

    public async Task<int> AddReservationAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
        return reservation.IdReservation;

    }

    public async Task ConnectBoatToReservation(IEnumerable<Sailboat> listofBoats,Reservation reservation)
    {
        foreach (var boat in listofBoats)
        {
            _context.SailboatReservations.AddAsync(new Sailboat_Reservation()
            {
                IdReservation = reservation.IdReservation,
                IdSailboat = boat.IdSailboat
            });
        }
        await _context.SaveChangesAsync();
    }
}