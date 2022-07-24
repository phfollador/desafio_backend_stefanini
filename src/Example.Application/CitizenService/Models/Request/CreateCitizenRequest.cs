using Example.Domain.CitizenAggregate;

namespace Example.Application.CitizenService.Models.Request
{
    public class CreateCitizenRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Cpf Cpf { get; set; }
        public int CityId { get; set; }
    }
}
