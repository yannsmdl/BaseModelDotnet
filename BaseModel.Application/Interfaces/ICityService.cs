using BaseModel.Application.DTOs;
using BaseModel.Application.Shareds;
using FluentValidation.Results;

namespace BaseModel.Application.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDTO>> GetAll();
        Task<CityDTO?> GetById(Guid Id);
        Task<CityDTO?> GetByNameAndUf(string name, string uf);
        Task<ValidationResultWithData<Guid>> Add(CityDTO category);
        Task<ValidationResult> Update(CityDTO category);
        Task<ValidationResult> Remove(Guid Id);
        Task<IEnumerable<CityDTO>> GetByStateId(Guid StateId);
    }
}
