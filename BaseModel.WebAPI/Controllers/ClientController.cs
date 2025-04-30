using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Shareds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseModel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        public ClientController
        (
            IClientService clientService
        )
        {
            _clientService = clientService;
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClientDTO clientDTO)
        {
            if (clientDTO == null) return BadRequest("Invalid Data");
            var result = await _clientService.Add(clientDTO);
            if (!result.ValidationResult.IsValid)
            {
                var firstError = result.ValidationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAll()
        {
            var clients = await _clientService.GetAll();
            if (clients == null)
            {
                return NotFound("Client not Founds");
            }
            return Ok(clients);
        }
        [HttpGet("{Id:Guid}", Name = "GetClientById")]
        public async Task<ActionResult<ClientDTO>> GetById(Guid Id)
        {
            var client = await _clientService.GetById(Id);
            if (client == null) return NotFound("Client not Found");
            return Ok(client);
        }
        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult> Update([FromBody] ClientDTO clientDTO, Guid Id)
        {
            if (clientDTO == null) return BadRequest("Invalid Data");
            clientDTO.Id = Id;
            var result = await _clientService.Update(clientDTO);
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
            var result = await _clientService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}