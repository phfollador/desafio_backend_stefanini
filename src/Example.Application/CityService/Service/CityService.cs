﻿using Example.Application.CityService.Models.Dtos;
using Example.Application.CityService.Models.Request;
using Example.Application.CityService.Models.Response;
using Example.Application.Common;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.CityService.Service
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly ExampleContext _db;

        public CityService(ILogger<CityService> logger, ExampleContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCityResponse> GetAllAsync()
        {
            var entity = await _db.Cities.ToListAsync();
            return new GetAllCityResponse
            {
                Cities = entity.Select(a => (CityDto)a).ToList()
            };
        }

        public async Task<GetByIdCityResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdCityResponse();

            var entity = await _db.Cities.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null) response.City = (CityDto)entity;

            return response;
        }

        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var newCity = Domain.CityAggregate.City.Create(request.Name, request.UF);

            _db.Cities.Add(newCity);

            await _db.SaveChangesAsync();

            return new CreateCityResponse { Id = newCity.Id };
        }

        public async Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var entity = await _db.Cities.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.Update(request.Name, request.UF);
                await _db.SaveChangesAsync();
            }

            return new UpdateCityResponse();
        }

        public async Task<DeleteCityResponse> DeleteAsync(int id)
        {
            var entity = await _db.Cities.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCityResponse();
        }
    }
}
