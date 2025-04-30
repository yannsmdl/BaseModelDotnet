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
    public class ProfessionController : BaseController
    {
        private readonly IProfessionService _professionService;
        public ProfessionController
        (
            IProfessionService professionService
        )
        {
            _professionService = professionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessionDTO>>> GetAll()
        {
            var professions = await _professionService.GetAll();
            if (professions == null)
            {
                return NotFound("Profissões não encontradas");
            }
            return Ok(professions);
        }
        [HttpGet("{Id:Guid}", Name = "GetProfessionById")]
        public async Task<ActionResult<ProfessionDTO>> GetById(Guid Id)
        {
            var profession = await _professionService.GetById(Id);
            if (profession == null) return NotFound("Profissão não encontrada");
            return Ok(profession);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProfessionDTO professionDTO)
        {
            var result = await _professionService.Add(professionDTO);
            if (!result.ValidationResult.IsValid)
            {
                var firstError = result.ValidationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok(result.Data);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] ProfessionDTO professionDTO, Guid Id)
        {
            professionDTO.Id = Id;
            var result = await _professionService.Update(professionDTO);
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
            var result = await _professionService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}