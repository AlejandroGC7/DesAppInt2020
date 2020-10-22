using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAGC.Models
{
    public class Room
    {
        [Key]
        [Display(Name="Room Number")]
        public int RoomID {get; set;}
        public int RoomTypeID {get; set;}
        public int RoomBandID {get; set;}
        public int RoomPriceID {get; set;}
        [Required]
        [Display(Name="Floor")]
        [StringLength(20)]
        [Range(1,10)]
        public string Floor {get; set;}
        [Display(Name="Additional Notes")]
        [StringLength(200,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Additional Notes")]
        public string AdditionalNotes {get; set;}

        //Relación uno a muchos con las tablas BookingRoom y RoomFacilities
        public ICollection<BookingRoom> BookingsRooms {get; set;}
        public ICollection<RoomFacilities> RoomsFacilities {get; set;}

        //Relación muchos a uno con las tablas RoomType, RoomBand y RoomPrice
        public RoomType RoomType {get; set;}
        public RoomBand RoomBand {get; set;}
        public RoomPrice RoomPrice {get; set;}
    }
}