using Microsoft.EntityFrameworkCore;
using Test2Practice1.DataBase.Context;
using Test2Practice1.Database.Entities;


namespace Test2Practice1.Api.Repositories;

public class BoatStandardRepository : IBoatStandardRepository
{
    private readonly DataBaseCOntext _context;

    public BoatStandardRepository(DataBaseCOntext context)
    {
        _context = context;
    }


    public async Task<BoatStandard?> GetBoatStandard(int idBoatStandard)
    {
        return await _context.BoatStandards.FindAsync(idBoatStandard);
    }
}