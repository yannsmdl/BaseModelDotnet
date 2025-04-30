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
    public class EmailClientController : BaseController
    {
        private readonly IEmailClientService _emailClientService;
        public EmailClientController
        (
            IEmailClientService emailClientService
        )
        {
            _emailClientService = emailClientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailClientDTO>>> GetAll()
        {
            var categories = await _emailClientService.GetAll();
            return Ok(categories);
        }
        [HttpGet("{Id:Guid}", Name = "GetEmailClientById")]
        public async Task<ActionResult<EmailClientDTO>> GetById(Guid Id)
        {
            var emailClient = await _emailClientService.GetById(Id);
            if (emailClient == null) return NotFound("Email do cliente não encontrado");
            return Ok(emailClient);
        }
        [HttpGet("state/{Id:Guid}")]
        public async Task<ActionResult<IEnumerable<EmailClientDTO>>> GetStateById(Guid StateId)
        {
            var emailClient = await _emailClientService.GetByStateId(StateId);
            return Ok(emailClient);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] EmailClientDTO emailClientDTO, Guid Id)
        {
            emailClientDTO.Id = Id;
            var result = await _emailClientService.Update(emailClientDTO);
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
            var result = await _emailClientService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}