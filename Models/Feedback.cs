using System.ComponentModel.DataAnnotations;

namespace RentalSystems.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }

        public string Suggestions { get; set; }

    }
}
