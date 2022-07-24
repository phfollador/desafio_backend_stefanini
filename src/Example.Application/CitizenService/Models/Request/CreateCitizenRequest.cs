using Example.Domain.CitizenAggregate;

namespace Example.Application.CitizenService.Models.Request
{
    public class CreateCitizenRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public int CityId { get; set; }
    }
}
