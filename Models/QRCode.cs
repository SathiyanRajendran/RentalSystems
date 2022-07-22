using System.ComponentModel.DataAnnotations;

namespace RentalSystems.Models
{
    public class QRCode
    {
        public int id { get; set; }
        [Display(Name = "Enter QR Code Text")]
        public string QRCodeText
        {
            get;
            set;
        }
    }
}
