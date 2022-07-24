using Example.Application.CitizenService.Models.Dtos;
using Example.Application.CitizenService.Models.Request;
using Example.Application.CitizenService.Models.Response;
using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Response;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.CitizenService.Service
{
    public class CitizenService : BaseService<CitizenService>, ICitizenService
    {
        private readonly ExampleContext _db;

        public CitizenService(ILogger<CitizenService> logger, ExampleContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCitizenResponse> GetAllAsync()
        {
            var entity = await _db.Citizens.ToListAsync();
            return new GetAllCitizenResponse()
            {
                Citizens = entity != null ? entity.Select(a => (CitizenDto)a).ToList() : new List<CitizenDto>()
            };
        }

        public async Task<GetByIdCitizenResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdCitizenResponse();
            var entity = await _db.Citizens.FirstOrDefaultAsync(item => item.Id == id);
            if (entity != null) response.Citizen = (CitizenDto)entity;

            return response;
        }

        public async Task<CreateCitizenResponse> CreateAsync(CreateCitizenRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newCitizen = Domain.CitizenAggregate.Citizen.Create(request.Name, request.Cpf, request.Age, request.CityId);
            _db.Citizens.Add(newCitizen);
            await _db.SaveChangesAsync();

            return new CreateCitizenResponse() { Id = newCitizen.Id };
        }

        public async Task<UpdateCitizenResponse> UpdateAsync(int id, UpdateCitizenRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Citizens.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Name, request.Age, request.CityId);
                await _db.SaveChangesAsync();
            }

            return new UpdateCitizenResponse();
        }

        public async Task<DeleteCitizenResponse> DeleteAsync(int id)
        {

            var entity = await _db.Citizens.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCitizenResponse();
        }
    }
}
