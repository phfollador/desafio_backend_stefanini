using Microsoft.AspNetCore.Mvc;
using Example.Application.CityService.Service;
using Example.Application.CityService.Models.Request;

namespace Example.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : BaseController
    {
        private readonly ICityService _citieService;

        public CitiesController(ILogger<CitiesController> logger, ICityService service) : base()
        {
            _citieService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var action = await _citieService.GetAllAsync();
                return Ok(action);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var action = await _citieService.GetByIdAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCityRequest request)
        {
            try
            {
                var action = await _citieService.CreateAsync(request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPut("{id")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCityRequest request)
        {
            try
            {
                var action = await _citieService.UpdateAsync(id, request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpDelete("{id")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var action = await _citieService.DeleteAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }
    }
}
