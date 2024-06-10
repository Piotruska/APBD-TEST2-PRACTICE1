using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Database.Configs;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .HasKey(x => x.IdReservation);
        
        builder
            .Property(x => x.IdReservation)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder
            .Property(x => x.DateFrom)
            .IsRequired();
        
        builder
            .Property(x => x.DateTo)
            .IsRequired();
        
        builder
            .Property(x => x.Capasity)
            .IsRequired();
        
        builder
            .Property(x => x.NumOfBoats)
            .IsRequired();
        
        builder
            .Property(x => x.Fulfilled)
            .IsRequired();
        
        builder
            .Property(x => x.Price);
        
        builder
            .Property(x => x.CancelReason)
            .HasMaxLength(200);

        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdBoatStandard);
        
        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.IdClient);
        
        builder
            .ToTable("Reservation", "Test2Practice1");
    }
}