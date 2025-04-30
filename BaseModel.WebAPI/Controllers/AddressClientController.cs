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
    public class AddressClientController : BaseController
    {
        private readonly IAddressClientService _addressClientService;
        public AddressClientController
        (
            IAddressClientService addressClientService
        )
        {
            _addressClientService = addressClientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressClientDTO>>> GetAll()
        {
            var categories = await _addressClientService.GetAll();
            if (categories == null)
            {
                return NotFound("AddressClient not Founds");
            }
            return Ok(categories);
        }
        [HttpGet("{Id:Guid}", Name = "GetAddressClientById")]
        public async Task<ActionResult<AddressClientDTO>> GetById(Guid Id)
        {
            var addressClient = await _addressClientService.GetById(Id);
            if (addressClient == null) return NotFound("AddressClient not Found");
            return Ok(addressClient);
        }
        [HttpGet("state/{Id:Guid}")]
        public async Task<ActionResult<IEnumerable<AddressClientDTO>>> GetStateById(Guid StateId)
        {
            var addressClient = await _addressClientService.GetByStateId(StateId);
            return Ok(addressClient);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] AddressClientDTO addressClientDTO, Guid Id)
        {
            if (addressClientDTO == null) return BadRequest("Invalid Data");
            addressClientDTO.Id = Id;
            var result = await _addressClientService.Update(addressClientDTO);
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
            var result = await _addressClientService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}