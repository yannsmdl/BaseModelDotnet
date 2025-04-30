using BaseModel.Application.DTOs;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface IEmailClientService
    {
        Task<IEnumerable<EmailClientDTO>> GetAll();
        Task<EmailClientDTO?> GetById(Guid Id);
        Task Add(EmailClientDTO category);
        Task<ValidationResult> Update(EmailClientDTO category);
        Task<ValidationResult> Remove(Guid Id);
        Task<IEnumerable<EmailClientDTO>> GetByStateId(Guid StateId);
        Task RemoveByClientId(Guid clientId);
    }
}
