using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Database.Configs;

public class ClientCategoryConfiguration : IEntityTypeConfiguration<ClientCategory>
{
    public void Configure(EntityTypeBuilder<ClientCategory> builder)
    {
        builder
            .HasKey(x => x.IdClientCategory);
        
        builder
            .Property(x => x.IdClientCategory)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.DicsountPerc)
            .IsRequired();
        
        builder
            .ToTable("ClientCategory", "Test2Practice1");
    }
}