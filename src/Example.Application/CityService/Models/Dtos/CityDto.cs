using Example.Domain.CityAggregate;
using System.ComponentModel.DataAnnotations;

namespace Example.Application.CityService.Models.Dtos
{
    public class CityDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "City name must be informed")]
        [Display(Name = "City name")]
        [StringLength(64, ErrorMessage = "Invalid name")]
        public string Name { get; set; }
        public UF UF { get; set; }

        public static explicit operator CityDto(City c)
        {
            return new CityDto
            {
                Id = c.Id,
                Name = c.Name,
                UF = c.UF
            };
        }
    }
}
