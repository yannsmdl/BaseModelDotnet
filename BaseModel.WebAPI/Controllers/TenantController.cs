using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Shareds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseModel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantController : BaseController
    {
        private readonly ITenantService _tenantService;
        public TenantController
        (
            ITenantService tenantService
        )
        {
            _tenantService = tenantService;
        }
        [HttpGet("TenantUrl")]
        public async Task<ActionResult> GetByTenantUrl(string TenantUrl)
        {
            var tenant = await _tenantService.GetByTenantUrl(TenantUrl);
            if (tenant == null) return NotFound("Tenant not Found");
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<TenantDTO>>> GetAll()
        {
            var categories = await _tenantService.GetAll();
            if (categories == null)
            {
                return NotFound("Tenant not Founds");
            }
            return Ok(categories);
        }
        [HttpGet("{Id:Guid}", Name = "GetTenantById")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TenantDTO>> GetById(Guid Id)
        {
            var tenant = await _tenantService.GetById(Id);
            if (tenant == null) return NotFound("Tenant not Found");
            return Ok(tenant);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([FromBody] TenantDTO tenantDTO)
        {
            var result = await _tenantService.Add(tenantDTO);

            if (!result.ValidationResult.IsValid)
            {
                var firstError = result.ValidationResult.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok(result.Data);
        }

        [HttpDelete("{Id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var result = await _tenantService.Remove(Id);
            if (!result.IsValid)
            {
                var firstError = result.Errors.FirstOrDefault()?.ErrorMessage ?? "Erro inesperado.";
                return BadRequest(new ErrorResponse(firstError));
            }

            return Ok();
        }
    }
}