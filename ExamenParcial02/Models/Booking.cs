using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAGC.Models
{
    public class Booking
    {
        [Key]
        [Display(Name="Booking Number")]
        public int BookingID {get; set;}
        public int CustomerID {get; set;}
        [Required]
        [Display(Name="Date Made")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime DateBookingMade {get; set;}
        [Required]
        [Display(Name="Time Made")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:hh:mm:ss tt}", ApplyFormatInEditMode=true)]
        public DateTime? TimeBookingMade {get; set;}
        [Required]
        [Display(Name="Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime BookedStartDate {get; set;}
        [Required]
        [Display(Name="End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime BookedEndDate {get; set;}
        [Required]
        [Display(Name="Payment Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime TotalPaymentDueDate {get; set;}
        [Required]
        [Display(Name="Payment Due Amount")]
        [DataType(DataType.Currency)]
        [Column(TypeName="Payment")]
        public decimal TotalPaymentDueAmount {get; set;}
        [Required]
        [Display(Name="Total Payment Made On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime TotalPaymentMadeOn {get; set;}
        [Display(Name="Booking Comments")]
        [StringLength(200,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Booking Comments")]
        public string BookingComments {get; set;}
        
        [NotMapped]
        public string FullBooking => DateBookingMade + " - " + TimeBookingMade;

        //Relación uno a muchos con las tablas BookingRoom y Payment
        public ICollection<BookingRoom> BookingsRooms {get; set;}
        public ICollection<Payment> Payments {get; set;}

        //Relación muchos a uno con la tabla Customer
        public Customer Customer {get; set;}
        
    }
}