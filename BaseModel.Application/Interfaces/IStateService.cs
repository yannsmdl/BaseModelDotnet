using BaseModel.Application.DTOs;
using BaseModel.Application.Shareds;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<StateDTO>> GetAll();
        Task<StateDTO?> GetById(Guid Id);
        Task<ValidationResultWithData<Guid>> Add(StateDTO category);
        Task<ValidationResult> Update(StateDTO category);
        Task<ValidationResult> Remove(Guid Id);
    }
}
