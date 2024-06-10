using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2Practice1.Database.Entities;

namespace Test2Practice1.Database.Configs;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasKey(x => x.IdClient);
        
        builder
            .Property(x => x.IdClient)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.Birthday)
            .IsRequired();
        
        builder
            .Property(x => x.Pesel)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(x => x.IdClientCategory)
            .IsRequired();
        
        builder
            .HasOne(x => x.ClientCategory)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.IdClientCategory);
        
        builder
            .ToTable("Client", "Test2Practice1");
    }
}