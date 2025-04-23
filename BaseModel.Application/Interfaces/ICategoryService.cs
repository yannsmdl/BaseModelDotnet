using BaseModel.Application.DTOs;

namespace BaseModel.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO?> GetById(Guid Id);
        Task Add(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Remove(Guid Id);
    }
}
