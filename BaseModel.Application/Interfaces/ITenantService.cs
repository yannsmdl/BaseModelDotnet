using BaseModel.Application.DTOs;
using BaseModel.Application.Shareds;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface ITenantService
    {
        Task<IEnumerable<TenantDTO>> GetAll();
        Task<TenantDTO?> GetById(Guid Id);
        Task<ValidationResultWithData<Guid>> Add(TenantDTO tenant);
        Task<ValidationResult> Update(TenantDTO category);
        Task<ValidationResult> Remove(Guid Id);
        Task<TenantDTO?> GetByTenantUrl(string tenantUrl);
    }
}
