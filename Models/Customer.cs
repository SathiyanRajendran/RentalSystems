using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalSystems.Models
{
    public class Customer
    {
        [Key]
       public int CustomerId { get; set; }
        public int? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Owner Owner { get; set; }
       public string CustomerName { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set; }
       public string IdProof { get; set; }
        public long MobileNo { get; set; }
        public string Email_Id { get; set; }

    }
}
