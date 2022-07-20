using System.ComponentModel.DataAnnotations;

namespace RentalSystems.Models
{
    public class Admintable
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public int AdminPassword { get; set; }
    }
}
