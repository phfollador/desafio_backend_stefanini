namespace Example.Application.CitizenService.Models.Request
{
    public class UpdateCitizenRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
    }
}
