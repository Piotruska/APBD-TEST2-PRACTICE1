using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Database.Configs;

public class Sailboat_ReservationConfiguration : IEntityTypeConfiguration<Sailboat_Reservation>
{
    public void Configure(EntityTypeBuilder<Sailboat_Reservation> builder)
    {
        builder
            .HasKey(x => new {x.IdReservation,x.IdSailboat});
        
        builder
            .HasOne(x => x.Sailboat)
            .WithMany(x => x.SailboatReservations)
            .HasForeignKey(x => x.IdSailboat)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(x => x.Reservation)
            .WithMany(x => x.SailboatReservations)
            .HasForeignKey(x => x.IdReservation)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .ToTable("Sailboat_Reservation", "Test2Practice1");
    }
}