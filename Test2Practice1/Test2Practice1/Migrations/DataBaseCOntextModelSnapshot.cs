﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test2Practice1.DataBase.Context;

#nullable disable

namespace Test2Practice1.Migrations
{
    [DbContext(typeof(DataBaseCOntext))]
    partial class DataBaseCOntextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test2Practice1.Database.Entities.BoatStandard", b =>
                {
                    b.Property<int>("IdBoatStandard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBoatStandard"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdBoatStandard");

                    b.ToTable("BoatStandard", "Test2Practice1");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdClientCategory")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClient");

                    b.HasIndex("IdClientCategory");

                    b.ToTable("Client", "Test2Practice1");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.ClientCategory", b =>
                {
                    b.Property<int>("IdClientCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClientCategory"));

                    b.Property<int>("DicsountPerc")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClientCategory");

                    b.ToTable("ClientCategory", "Test2Practice1");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"));

                    b.Property<string>("CancelReason")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Capasity")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Fulfilled")
                        .HasColumnType("bit");

                    b.Property<int>("IdBoatStandard")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("NumOfBoats")
                        .HasColumnType("int");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("IdReservation");

                    b.HasIndex("IdBoatStandard");

                    b.HasIndex("IdClient");

                    b.ToTable("Reservation", "Test2Practice1");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Sailboat", b =>
                {
                    b.Property<int>("IdSailboat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSailboat"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdBoatStandard")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("IdSailboat");

                    b.HasIndex("IdBoatStandard");

                    b.ToTable("Sailboat", "Test2Practice1");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Sailboat_Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .HasColumnType("int");

                    b.Property<int>("IdSailboat")
                        .HasColumnType("int");

                    b.HasKey("IdReservation", "IdSailboat");

                    b.HasIndex("IdSailboat");

                    b.ToTable("Sailboat_Reservation", "Test2Practice1");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Client", b =>
                {
                    b.HasOne("Test2Practice1.Database.Entities.ClientCategory", "ClientCategory")
                        .WithMany("Clients")
                        .HasForeignKey("IdClientCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientCategory");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Reservation", b =>
                {
                    b.HasOne("Test2Practice1.Database.Entities.BoatStandard", "BoatStandard")
                        .WithMany("Reservations")
                        .HasForeignKey("IdBoatStandard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test2Practice1.Database.Entities.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoatStandard");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Sailboat", b =>
                {
                    b.HasOne("Test2Practice1.Database.Entities.BoatStandard", "BoatStandard")
                        .WithMany("Sailboats")
                        .HasForeignKey("IdBoatStandard")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoatStandard");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Sailboat_Reservation", b =>
                {
                    b.HasOne("Test2Practice1.Database.Entities.Reservation", "Reservation")
                        .WithMany("SailboatReservations")
                        .HasForeignKey("IdReservation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Test2Practice1.Database.Entities.Sailboat", "Sailboat")
                        .WithMany("SailboatReservations")
                        .HasForeignKey("IdSailboat")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Sailboat");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.BoatStandard", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Sailboats");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.ClientCategory", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Reservation", b =>
                {
                    b.Navigation("SailboatReservations");
                });

            modelBuilder.Entity("Test2Practice1.Database.Entities.Sailboat", b =>
                {
                    b.Navigation("SailboatReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
