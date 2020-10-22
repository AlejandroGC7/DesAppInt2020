using System;
using System.ComponentModel.DataAnnotations;

namespace HotelAGC.Models
{
    public class RoomFacilities
    {
        [Key]
        public int RoomID {get; set;}
        public int FacilityID {get; set;}
        [Required]
        [Display(Name="Facility Details")]
        [StringLength(200,MinimumLength=10)]
        public string FacilityDetails {get; set;}
        
        //Relación muchos a uno con las tablas FacilitieList y Room
        public FacilitieList FacilitieList {get; set;}
        public Room Room {get; set;}
    }
}