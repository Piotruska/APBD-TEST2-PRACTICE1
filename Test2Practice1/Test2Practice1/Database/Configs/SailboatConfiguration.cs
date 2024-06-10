using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Database.Configs;

public class SailboatConfiguration : IEntityTypeConfiguration<Sailboat>
{
    public void Configure(EntityTypeBuilder<Sailboat> builder)
    {
        builder
            .HasKey(x => x.IdSailboat);
        
        builder
            .Property(x => x.IdSailboat)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.Capacity)
            .IsRequired();
        
        builder
            .Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.Price)
            .IsRequired();

        builder
            .HasOne(x => x.BoatStandard)
            .WithMany(x => x.Sailboats)
            .HasForeignKey(x => x.IdBoatStandard);
        
        builder
            .ToTable("Sailboat", "Test2Practice1");
    }
}