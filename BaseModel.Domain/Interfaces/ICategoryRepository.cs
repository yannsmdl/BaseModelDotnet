using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category?> GetById(Guid Id);
        void Add(Category category);
        void Update(Category category);
        void Remove(Category category);
    }
}
