using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Shareds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseModel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        public CityController
        (
            ICityService cityService
        )
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetAll()
        {
            var categories = await _cityService.GetAll();
            if (categories == null)
            {
                return NotFound("City not Founds");
            }
            return Ok(categories);
        }
        [HttpGet("{Id:Guid}", Name = "GetCityById")]
        public async Task<ActionResult<CityDTO>> GetById(Guid Id)
        {
            var city = await _cityService.GetById(Id);
            if (city == null) return NotFound("City not Found");
            return Ok(city);
        }
        [HttpGet("state/{Id:Guid}")]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetStateById(Guid StateId)
        {
            var city = await _cityService.GetByStateId(StateId);
            return Ok(city);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CityDTO cityDTO)
        {
            if (cityDTO == null) return BadRequest("Invalid Data");
            var result = await _cityService.Add(cityDTO);
            if (!result.ValidationResult.IsValid)
            {
                var firstError = result.ValidationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok(result.Data);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] CityDTO cityDTO, Guid Id)
        {
            if (cityDTO == null) return BadRequest("Invalid Data");
            cityDTO.Id = Id;
            var result = await _cityService.Update(cityDTO);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var result = await _cityService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}