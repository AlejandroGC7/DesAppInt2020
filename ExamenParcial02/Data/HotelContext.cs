using HotelAGC.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAGC.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings {get; set;}
        public DbSet<BookingRoom> BookingsRooms {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<FacilitieList> FacilitieLists {get; set;}
        public DbSet<Guest> Guests {get; set;}
        public DbSet<Payment> Payments {get; set;}
        public DbSet<PaymentMethod> PaymentMethods {get; set;}
        public DbSet<Room> Rooms {get; set;}
        public DbSet<RoomBand> RoomBands {get; set;}
        public DbSet<RoomFacilities> RoomsFacilities {get; set;}
        public DbSet<RoomPrice> RoomPrices {get; set;}
        public DbSet<RoomType> RoomTypes {get; set;}

        //API Fluida
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<BookingRoom>().ToTable("BookingRoom");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<FacilitieList>().ToTable("FacilitieList");
            modelBuilder.Entity<Guest>().ToTable("Guest");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<RoomBand>().ToTable("RoomBand");
            modelBuilder.Entity<RoomFacilities>().ToTable("RoomFacilities");
            modelBuilder.Entity<RoomPrice>().ToTable("RoomPrice");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            
            modelBuilder.Entity<BookingRoom>().HasKey(b => new { b.BookingID, b.RoomID, b.GuestID });

            modelBuilder.Entity<RoomFacilities>().HasKey(e => new { e.RoomID, e.FacilityID });
        }
    }
}