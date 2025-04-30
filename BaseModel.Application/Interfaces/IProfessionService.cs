using BaseModel.Application.DTOs;
using BaseModel.Application.Shareds;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface IProfessionService
    {
        Task<IEnumerable<ProfessionDTO>> GetAll();
        Task<ProfessionDTO?> GetById(Guid Id);
        Task<ValidationResultWithData<Guid>> Add(ProfessionDTO category);
        Task<ValidationResult> Update(ProfessionDTO category);
        Task<ValidationResult> Remove(Guid Id);
    }
}
