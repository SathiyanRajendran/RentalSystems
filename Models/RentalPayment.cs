using System;
using System.ComponentModel.DataAnnotations;

namespace RentalSystems.Models
{
    public class RentalPayment
    {
        [Key]
        public int Id { get; set; } 
        public string CardNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Charge { get; set; }
        public int GST { get; set; }
        public int Total { get; set; }

    }
}
