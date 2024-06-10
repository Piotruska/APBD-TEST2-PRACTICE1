using Microsoft.EntityFrameworkCore;
using Test2Practice1.Database.Configs;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.DataBase.Context;

public class DataBaseCOntext : Microsoft.EntityFrameworkCore.DbContext
{
    protected DataBaseCOntext()
    {
    }

    public DataBaseCOntext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BoatStandard> BoatStandards  { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }
    public DbSet<Sailboat_Reservation> SailboatReservations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BoatStandardConfiguration());
        modelBuilder.ApplyConfiguration(new ClientCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        modelBuilder.ApplyConfiguration(new Sailboat_ReservationConfiguration());
        modelBuilder.ApplyConfiguration(new SailboatConfiguration());
    }
}