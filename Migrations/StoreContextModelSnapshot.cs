﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreModel.Data;

namespace Secheli_Stefania_Proiect.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Artist")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlbumID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.RecordedAlbum", b =>
                {
                    b.Property<int>("AlbumID")
                        .HasColumnType("int");

                    b.Property<int>("RecorderID")
                        .HasColumnType("int");

                    b.HasKey("AlbumID", "RecorderID");

                    b.HasIndex("RecorderID");

                    b.ToTable("RecordedAlbum");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Recorder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adress")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("RecorderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Recorder");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Order", b =>
                {
                    b.HasOne("Secheli_Stefania_Proiect.Models.Album", "Album")
                        .WithMany("Orders")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Secheli_Stefania_Proiect.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.RecordedAlbum", b =>
                {
                    b.HasOne("Secheli_Stefania_Proiect.Models.Album", "Album")
                        .WithMany("RecordedAlbums")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Secheli_Stefania_Proiect.Models.Recorder", "Recorder")
                        .WithMany("RecordedAlbums")
                        .HasForeignKey("RecorderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("Recorder");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Album", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("RecordedAlbums");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Secheli_Stefania_Proiect.Models.Recorder", b =>
                {
                    b.Navigation("RecordedAlbums");
                });
#pragma warning restore 612, 618
        }
    }
}