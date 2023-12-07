﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthPoleGiftSystem.NorthPole.Data;

#nullable disable

namespace NorthPoleGiftSystem.Migrations
{
    [DbContext(typeof(NorthPoleDbContext))]
    [Migration("20231201182136_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NorthPoleGiftSystem.NorthPole.Data.Entities.ElfEntity", b =>
                {
                    b.Property<int>("ElfID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElfID"));

                    b.Property<string>("ElfName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElfRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopID")
                        .HasColumnType("int");

                    b.HasKey("ElfID");

                    b.HasIndex("WorkshopID");

                    b.ToTable("Elves");
                });

            modelBuilder.Entity("NorthPoleGiftSystem.NorthPole.Data.Entities.GiftEntity", b =>
                {
                    b.Property<int>("GiftID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiftID"));

                    b.Property<string>("GiftDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WishlistID")
                        .HasColumnType("int");

                    b.Property<int>("WorkshopID")
                        .HasColumnType("int");

                    b.HasKey("GiftID");

                    b.HasIndex("WorkshopID");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("NorthPoleGiftSystem.NorthPole.Data.Entities.WishlistEntity", b =>
                {
                    b.Property<int>("WishlistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WishlistID"));

                    b.Property<int>("ElfID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("WishlistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WishlistID");

                    b.HasIndex("ElfID");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("NorthPoleGiftSystem.NorthPole.Data.Entities.WorkshopEntity", b =>
                {
                    b.Property<int>("WorkshopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkshopID"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupervisorID")
                        .HasColumnType("int");

                    b.Property<int>("WorkshopCapacity")
                        .HasColumnType("int");

                    b.HasKey("WorkshopID");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("NorthPoleGiftSystem.NorthPole.Data.Entities.ElfEntity", b =>
                {
                    b.HasOne("NorthPoleGiftSystem.NorthPole.Data.Entities.WorkshopEntity", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("NorthPoleGiftSystem.NorthPole.Data.Entities.GiftEntity", b =>
                {
                    b.HasOne("NorthPoleGiftSystem.NorthPole.Data.Entities.WorkshopEntity", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("NorthPoleGiftSystem.NorthPole.Data.Entities.WishlistEntity", b =>
                {
                    b.HasOne("NorthPoleGiftSystem.NorthPole.Data.Entities.ElfEntity", "Elf")
                        .WithMany()
                        .HasForeignKey("ElfID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Elf");
                });
#pragma warning restore 612, 618
        }
    }
}
