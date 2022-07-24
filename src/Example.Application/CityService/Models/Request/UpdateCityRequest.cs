using Example.Domain.CityAggregate;

namespace Example.Application.CityService.Models.Request
{
    public class UpdateCityRequest
    {
        public string Name { get; set; }
        public UF? UF { get; set; }
    }
}
