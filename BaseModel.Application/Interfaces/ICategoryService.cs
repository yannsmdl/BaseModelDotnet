using BaseModel.Application.DTOs;
using BaseModel.Application.Shareds;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO?> GetById(Guid Id);
        Task<ValidationResultWithData<Guid>> Add(CategoryDTO category);
        Task<ValidationResult> Update(CategoryDTO category);
        Task<ValidationResult> Remove(Guid Id);
    }
}
