using Example.Application.CitizenService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CitizenService.Models.Response
{
    public class GetAllCitizenResponse : BaseResponse
    {
        public List<CitizenDto> Citizens { get; set; }
    }
}
