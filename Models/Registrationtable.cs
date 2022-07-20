using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalSystems.Models
{
    public class Registrationtable
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }


        [Display(Name = "Date of Registration")]

        public DateTime DOB { get; set; }

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Please enter an EmailId")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid EmailId")]
        public string EmailId { get; set; }

        [Required]

        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [NotMapped]
        public string CPassword { get; set; }
    }
}
