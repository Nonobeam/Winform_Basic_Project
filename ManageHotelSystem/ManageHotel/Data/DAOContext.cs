using System;
using System.Collections.Generic;
using System.Linq;
using ManageHotel.Model;
using Microsoft.EntityFrameworkCore;
using NguyenHuuPhucWPF.Model;

namespace ManageHotel.Data
{
    public class DAOContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<RoomInformation> RoomInformation { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<BookingDetail> BookingDetail { get; set; }
        public DbSet<BookingReservation> BookingReservation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ServerName = "desktop-4333geq\\huuphuc";
            string Database = "FUMiniHotelManagement";
            string user = "sa";
            string password = "123";
            optionsBuilder.UseSqlServer($"Server={ServerName};Database={Database};User Id={user};Password={password};Encrypt=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingDetail>()
                .HasKey(b => new { b.BookingReservationID, b.RoomID });
        }
    }
}
