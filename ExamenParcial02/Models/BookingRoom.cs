using System;
using System.ComponentModel.DataAnnotations;

namespace HotelAGC.Models
{
    public class BookingRoom
    {
        [Key]
        public int BookingID {get; set;}
        public int RoomID {get; set;}
        public int GuestID {get; set;}
        
        //Relación muchos a uno con las tablas Booking, Room y Guest
        public Booking Booking {get; set;}
        public Room Room {get; set;}
        public Guest Guest {get; set;}
    }
}