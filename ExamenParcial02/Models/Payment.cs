using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAGC.Models
{
    public class Payment
    {
        [Key]
        [Display(Name="Payment Number")]
        public int PaymentID {get; set;}
        public int BookingID {get; set;}
        public int CustomerID {get; set;}
        public int PaymentMethodID {get; set;}
        [Required]
        [Display(Name="Payment Amount")]
        [DataType(DataType.Currency)]
        [Column(TypeName="Payment")]
        public decimal PaymentAmount {get; set;}
        [Display(Name="Payment Comments")]
        [StringLength(200,MinimumLength=10)]
        [DisplayFormat(NullDisplayText="No Payments Comments")]
        public string PaymentComments {get; set;}
        
        //Relación muchos a uno con las tablas PaymentMethod y Customer
        public PaymentMethod PaymentMethod {get; set;}
        public Customer Customer {get; set;}
        //Relación muchos a muchos con la tabla BookingRoom
        public Booking Booking {get; set;}
    }
}