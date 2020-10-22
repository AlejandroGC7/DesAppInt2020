using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAGC.Models
{
    public class Guest
    {
        [Key]
        public int GuestID {get; set;}
        [Display(Name="Title")]
        [StringLength(50)]
        [DisplayFormat(NullDisplayText="No Title")]
        public string GuestTitle {get; set;}
        [Required]
        [Display(Name="Forenames")]
        [StringLength(50)]
        public string GuestForenames {get; set;}
        [Required]
        [Display(Name="Surnames")]
        [StringLength(50)]
        public string GuestSurnames {get; set;}
        [Required]
        [Display(Name="Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime GuestDOB {get; set;}
        [Required]
        [Display(Name="Street")]
        [StringLength(50)]
        public string GuestAddressStreet {get; set;}
        [Required]
        [Display(Name="Town")]
        [StringLength(50)]
        public string GuestAddressTown {get; set;}
        [Required]
        [Display(Name="County")]
        [StringLength(50)]
        public string GuestAddressCounty {get; set;}
        [Required]
        [Display(Name="Postal Code")]
        [StringLength(50)]
        public string GuestAddressPostalCode {get; set;}
        [Display(Name="Contact Phone")]
        [StringLength(10,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Contact Phone")]
        public string GuestContactPhone {get; set;}

        [NotMapped]
        public string FullName => GuestForenames + ", " + GuestSurnames;

        //Relación uno a muchos con la tabla BookingRoom
        public ICollection<BookingRoom> BookingsRooms {get; set;}
    }
}