using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelAGC.Models
{
    public class FacilitieList
    {
        [Key]
        public int FacilityID {get; set;}
        [Required]
        [Display(Name="Facility Desc")]
        [StringLength(250)]
        public string FacilityDesc{get; set;}

        //Relación uno a muchos con la tabla RoomFacilities
        public ICollection<RoomFacilities> RoomsFacilities {get; set;}  
    }
}    