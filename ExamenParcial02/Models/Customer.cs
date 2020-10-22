using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAGC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID {get; set;}
        [Display(Name="Title")]
        [StringLength(50)]
        [DisplayFormat(NullDisplayText="No Title")]
        public string CustomerTitle {get; set;}
        [Required]
        [Display(Name="Forenames")]
        [StringLength(50)]
        public string CustomerForenames {get; set;}
        [Required]
        [Display(Name="Surnames")]
        [StringLength(50)]
        public string CustomerSurnames {get; set;}
        [Required]
        [Display(Name="Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime CustomerDOB {get; set;}
        [Required]
        [Display(Name="Street")]
        [StringLength(50)]
        public string CustomerAddressStreet {get; set;}
        [Required]
        [Display(Name="Town")]
        [StringLength(50)]
        public string CustomerAddressTown {get; set;}
        [Required]
        [Display(Name="County")]
        [StringLength(50)]
        public string CustomerAddressCounty {get; set;}
        [Required]
        [Display(Name="Postal Code")]
        [StringLength(50)]
        public string CustomerAddressPostalCode {get; set;}
        [Display(Name="Home Phone")]
        [StringLength(10,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Home Phone")]
        public string CustomerHomePhone {get; set;}
        [Display(Name="Work Phone")]
        [StringLength(10,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Work Phone")]
        public string CustomerWorkPhone {get; set;}
        [Display(Name="Mobile Phone")]
        [StringLength(10,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Mobile Phone")]
        public string CustomerMobilePhone {get; set;}
        [Display(Name="E-mail")]
        [StringLength(50)]
        [DisplayFormat(NullDisplayText="No E-mail")]
        public string CustomerEmail {get; set;}
        
        [NotMapped]
        public string FullName => CustomerForenames + ", " + CustomerSurnames;

        //Relación uno a muchos con las tablas Booking y Payment
        public ICollection<Booking> Bookings {get; set;}
        public ICollection<Payment> Payments {get; set;}
    }
}