using System.ComponentModel.DataAnnotations;

namespace CitiesManager.WebAPI.Models
{
    public class City
    {
        [Key]
        [Required(ErrorMessage = "City name can not be blank")]
        public Guid CityId { get; set; }
        public string? CityName { get; set; }

    }
}
