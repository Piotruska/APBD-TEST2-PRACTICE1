using Test2Practice1.Database.Entities;

namespace Test2Practice1.Api.Repositories;

public interface IBoatStandardRepository
{
    public Task<BoatStandard?> GetBoatStandard(int idBoatStandard);
}