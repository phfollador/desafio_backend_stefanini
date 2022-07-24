using Example.Application.CitizenService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CitizenService.Models.Response
{
    public class GetByIdCitizenResponse : BaseResponse
    {
        public CitizenDto Citizen { get; set; }
    }
}
