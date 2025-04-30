
using BaseModel.Application.DTOs;
using BaseModel.Application.Shareds;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAll();
        Task<ClientDTO?> GetById(Guid Id);
        Task<ValidationResultWithData<Guid>> Add(ClientDTO category);
        Task<ValidationResult> Update(ClientDTO category);
        Task<ValidationResult> Remove(Guid Id);
    }
}
