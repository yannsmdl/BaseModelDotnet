using BaseModel.Application.DTOs;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface IPhoneClientService
    {
        Task<IEnumerable<PhoneClientDTO>> GetAll();
        Task<PhoneClientDTO?> GetById(Guid Id);
        Task Add(PhoneClientDTO category);
        Task<ValidationResult> Update(PhoneClientDTO category);
        Task<ValidationResult> Remove(Guid Id);
        Task<IEnumerable<PhoneClientDTO>> GetByStateId(Guid StateId);
        Task RemoveByClientId(Guid clientId);
    }
}
