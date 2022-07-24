using Microsoft.AspNetCore.Mvc;
using Example.Application.CitizenService.Service;
using Example.Application.CitizenService.Models.Request;

namespace Example.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenController : BaseController
    {
        private readonly ICitizenService _citizenService;

        public CitizenController(ILogger<CitizenController> logger, ICitizenService service) : base()
        {
            _citizenService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var action = await _citizenService.GetAllAsync();
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
                var action = await _citizenService.GetByIdAsync(id);
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
        public async Task<IActionResult> Post([FromBody] CreateCitizenRequest request)
        {
            try
            {
                var action = await _citizenService.CreateAsync(request);
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
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCitizenRequest request)
        {
            try
            {
                var action = await _citizenService.UpdateAsync(id, request);
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
                var action = await _citizenService.DeleteAsync(id);
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