using BaseModel.Application.DTOs;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface IAddressClientService
    {
        Task<IEnumerable<AddressClientDTO>> GetAll();
        Task<AddressClientDTO?> GetById(Guid Id);
        Task Add(AddressClientDTO category);
        Task<ValidationResult> Update(AddressClientDTO category);
        Task<ValidationResult> Remove(Guid Id);
        Task<IEnumerable<AddressClientDTO>> GetByStateId(Guid StateId);
        Task RemoveByClientId(Guid clientId);
    }
}
