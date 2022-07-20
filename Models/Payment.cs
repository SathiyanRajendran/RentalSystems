using System.ComponentModel.DataAnnotations;

namespace RentalSystems.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public string CouponCode { get; set; }
        public long Amount { get; set; }
        public float Offer { get; set; }
        public float ToPay { get; set; }

    }
}
