using System.ComponentModel.DataAnnotations;

namespace ApiTravelCompany.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }                     
        public string Username {get; set; }
        public string Password { get; set; }
    }
}
