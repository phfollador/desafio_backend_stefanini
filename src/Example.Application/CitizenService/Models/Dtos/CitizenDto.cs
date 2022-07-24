using Example.Domain.CitizenAggregate;
using Example.Domain.CityAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Example.Application.CitizenService.Models.Dtos
{
    public class CitizenDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Citizen name must be informed")]
        [Display(Name = "Citizen name")]
        [StringLength(64, ErrorMessage = "Invalid name")]
        public string Name { get; set; }
        public Cpf Cpf { get; set; }

        [Required(ErrorMessage = "Citizen name must be informed")]
        [Display(Name = "Citizen age")]
        [Range(0, 150, ErrorMessage = "Invalid age")]
        public int Age { get; set; }
        public City City { get; set; }

        public static explicit operator CitizenDto(Domain.CitizenAggregate.Citizen v)
        {
            return new CitizenDto()
            {
                Id = v.Id,
                Name = v.Name,
                Age = v.Age,
                Cpf = v.Cpf,
                City = v.City
            };
        }
    }
}
