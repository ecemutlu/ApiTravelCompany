using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTravelCompany.Models
{
    public class Booking
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("House")]
        public string HouseId { get; set; }
        [ForeignKey("User")]
        public string CustomerUsername { get; set; }
        [Required]
        public DateOnly DateFrom { get; set; }
        [Required]
        public DateOnly DateTo { get; set; }

        [Required]
        public virtual string CustomerNames { get; set; }
    }
}
