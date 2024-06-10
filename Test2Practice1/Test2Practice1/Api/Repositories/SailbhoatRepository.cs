using Microsoft.EntityFrameworkCore;
using Test2Practice1.DataBase.Context;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Repositories;

public class SailbhoatRepository : ISailboatRepository
{
    private readonly DataBaseCOntext _context;

    public SailbhoatRepository(DataBaseCOntext context)
    {
        _context = context;
    }
    
    public async Task<List<Sailboat>> GetOrderedListOfSailBoatsAsync(int boatStadard,DateTime Datefrom,DateTime Dateto)
    {
        return await _context.Sailboats
            .Join(_context.SailboatReservations, s => s.IdSailboat, sr => sr.IdSailboat, (s, sr) => new { s, sr })
            .Join(_context.Reservations, x => x.sr.IdReservation, r => r.IdReservation, (x, r) => new { x.s, x.sr, r })
            .Where(x => !((Datefrom <= x.r.DateTo) && (Datefrom >= x.r.DateFrom)))
            .Where(x => !((Dateto <= x.r.DateTo) && (Dateto >= x.r.DateFrom)))
            .Select(x => x.s)
            .Join(_context.BoatStandards, x => x.IdBoatStandard, y => y.IdBoatStandard, (x, y) => new { x, y })
            .Where(x => x.y.Level >= boatStadard)
            .OrderBy(X => X.y.Level)
            .Select(x => x.x)
            .ToListAsync();
    }
            
}