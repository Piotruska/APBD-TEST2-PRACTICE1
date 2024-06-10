using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Repositories;

public interface ISailboatRepository
{
    
    public Task<List<Sailboat>> GetOrderedListOfSailBoatsAsync(int boatStadard,DateTime Datefrom,DateTime Dateto);
}