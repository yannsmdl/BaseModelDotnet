using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<City>> GetAll();
        Task<City?> GetById(Guid Id);
        Task<City?> GetByNameAndUf(string name, string uf);
        Task<IEnumerable<City>> GetByStateId(Guid StateId);
        void Add(City City);
        void Update(City City);
        void Remove(City City);
    }
}
