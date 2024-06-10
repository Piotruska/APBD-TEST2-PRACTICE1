using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Database.Configs;

public class BoatStandardConfiguration : IEntityTypeConfiguration<BoatStandard>
{
    public void Configure(EntityTypeBuilder<BoatStandard> builder)
    {
        builder
            .HasKey(x => x.IdBoatStandard);
        
        builder
            .Property(x => x.IdBoatStandard)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.Level)
            .IsRequired();
        
        builder
            .ToTable("BoatStandard", "Test2Practice1");
    }
}