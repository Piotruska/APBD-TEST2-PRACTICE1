using Microsoft.EntityFrameworkCore;
using Test2Practice1.DataBase.Context;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Repositories;

public class ClientRepository : IClientsRepository
{
    private readonly DataBaseCOntext _context;

    public ClientRepository(DataBaseCOntext context)
    {
        _context = context;
    }

    
    public async Task<Client?> GetClientAsync(int idClient)
    {
        return await _context.Clients.FindAsync(idClient);
    }

    public async Task<int> GetDiscountAsync(int idClient)
    {
        var client = await _context.Clients.Include(x => x.ClientCategory).FirstOrDefaultAsync();
        return client.ClientCategory.DicsountPerc;
    }
}