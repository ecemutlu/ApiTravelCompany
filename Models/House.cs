using System.ComponentModel.DataAnnotations;

namespace ApiTravelCompany.Models
{
    public class House
    {
        [Key]
        public string Id { get; set; }
        public string Description { get; set; }=string.Empty;
        public int Capacity { get; set; }
        public string City { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool HasTv { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool HasWifi { get; set; }
        public bool HasPool { get; set; }            
       


    }
}
