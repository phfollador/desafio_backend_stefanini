using Example.Application.CitizenService.Models.Request;
using Example.Application.CitizenService.Models.Response;

namespace Example.Application.CitizenService.Service
{
    public interface ICitizenService
    {
        Task<GetAllCitizenResponse> GetAllAsync();
        Task<GetByIdCitizenResponse> GetByIdAsync(int id);
        Task<CreateCitizenResponse> CreateAsync(CreateCitizenRequest request);
        Task<UpdateCitizenResponse> UpdateAsync(int id, UpdateCitizenRequest request);
        Task<DeleteCitizenResponse> DeleteAsync(int id);
    }
}
