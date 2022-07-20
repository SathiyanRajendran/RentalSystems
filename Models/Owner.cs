using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalSystems.Models
{
    public class Owner
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleNo { get; set; }
        public string CompanyName { get; set; }
        public string Model { get; set; }
        public string Availability { get; set; }
        public string Photo { get; set; }
        public int Rentalperday { get; set; }
        public int Stocks { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
