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
    public class StateController : BaseController
    {
        private readonly IStateService _stateService;
        public StateController
        (
            IStateService stateService
        )
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetAll()
        {
            var categories = await _stateService.GetAll();
            if (categories == null)
            {
                return NotFound("State not Founds");
            }
            return Ok(categories);
        }
        [HttpGet("{Id:Guid}", Name = "GetStateById")]
        public async Task<ActionResult<StateDTO>> GetById(Guid Id)
        {
            var state = await _stateService.GetById(Id);
            if (state == null) return NotFound("State not Found");
            return Ok(state);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] StateDTO stateDTO)
        {
            var result = await _stateService.Add(stateDTO);
            if (!result.ValidationResult.IsValid)
            {
                var firstError = result.ValidationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok(result.Data);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] StateDTO stateDTO, Guid Id)
        {
            stateDTO.Id = Id;
            var result = await _stateService.Update(stateDTO);
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
            var result = await _stateService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}