using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreModel.Models;


namespace StoreModel.Data
{

    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Recorder> Recorders { get; set; }
        public DbSet<RecordedAlbum> RecordedAlbums { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Album>().ToTable("Album");
            modelBuilder.Entity<Recorder>().ToTable("Recorder");
            modelBuilder.Entity<RecordedAlbum>().ToTable("RecordedAlbum");
            modelBuilder.Entity<RecordedAlbum>()
            .HasKey(c => new { c.AlbumID, c.RecorderID });
        }
    }
    }


