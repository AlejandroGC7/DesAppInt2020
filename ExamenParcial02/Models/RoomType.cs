using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelAGC.Models
{
    public enum roomType{
        Individual, Doble, Cuadruple, Suite, JuniorSuite, GranSuite
    }

    public class RoomType
    {
        [Key]
        public int RoomTypeID {get; set;}
        [Required]
        [Display(Name="Type")]
        public roomType roomType {get; set;}

        //Relación uno a muchos con la tabla Rooms
        public ICollection<Room> Rooms {get; set;}
    }
}