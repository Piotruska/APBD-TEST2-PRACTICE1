

using Test2Practice1.DataBase.Context;

namespace Test2Practice1.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseCOntext _context;

    public UnitOfWork(DataBaseCOntext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}