﻿// <auto-generated />
using System;
using ControledeAliens.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControledeAliens.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControledeAliens.Models.Alien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.Property<int>("PowerId")
                        .HasColumnType("int");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Aliens");
                });

            modelBuilder.Entity("ControledeAliens.Models.Earth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlienId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExitTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlienId");

                    b.ToTable("AlienEntriesExits");
                });

            modelBuilder.Entity("ControledeAliens.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("ControledeAliens.Models.Power", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlienId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlienId");

                    b.ToTable("Powers");
                });

            modelBuilder.Entity("ControledeAliens.Models.Alien", b =>
                {
                    b.HasOne("ControledeAliens.Models.Planet", "Planet")
                        .WithMany()
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("ControledeAliens.Models.Earth", b =>
                {
                    b.HasOne("ControledeAliens.Models.Alien", "Alien")
                        .WithMany()
                        .HasForeignKey("AlienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alien");
                });

            modelBuilder.Entity("ControledeAliens.Models.Power", b =>
                {
                    b.HasOne("ControledeAliens.Models.Alien", null)
                        .WithMany("Powers")
                        .HasForeignKey("AlienId");
                });

            modelBuilder.Entity("ControledeAliens.Models.Alien", b =>
                {
                    b.Navigation("Powers");
                });
#pragma warning restore 612, 618
        }
    }
}
