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
    public class PhoneClientController : BaseController
    {
        private readonly IPhoneClientService _phoneClientService;
        public PhoneClientController
        (
            IPhoneClientService phoneClientService
        )
        {
            _phoneClientService = phoneClientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneClientDTO>>> GetAll()
        {
            var categories = await _phoneClientService.GetAll();
            return Ok(categories);
        }
        [HttpGet("{Id:Guid}", Name = "GetPhoneClientById")]
        public async Task<ActionResult<PhoneClientDTO>> GetById(Guid Id)
        {
            var phoneClient = await _phoneClientService.GetById(Id);
            if (phoneClient == null) return NotFound("Telefone do cliente não encontrado");
            return Ok(phoneClient);
        }
        [HttpGet("state/{Id:Guid}")]
        public async Task<ActionResult<IEnumerable<PhoneClientDTO>>> GetStateById(Guid StateId)
        {
            var phoneClient = await _phoneClientService.GetByStateId(StateId);
            return Ok(phoneClient);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] PhoneClientDTO phoneClientDTO, Guid Id)
        {
            phoneClientDTO.Id = Id;
            var result = await _phoneClientService.Update(phoneClientDTO);
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
            var result = await _phoneClientService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}