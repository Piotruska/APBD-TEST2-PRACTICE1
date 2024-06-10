using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Repositories;

public interface IClientsRepository
{
    public Task<Client?> GetClientAsync(int idClient);
    public Task<int> GetDiscountAsync(int idClient);

}