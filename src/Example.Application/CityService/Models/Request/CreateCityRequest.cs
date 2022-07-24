using Example.Domain.CityAggregate;

namespace Example.Application.CityService.Models.Request
{
    public class CreateCityRequest
    {
        public string Name { get; set; }
        public UF UF { get; set; }
    }
}
