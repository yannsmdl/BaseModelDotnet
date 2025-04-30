using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface IProfessionRepository : IRepository<Profession>
    {
        Task<IEnumerable<Profession>> GetAll();
        Task<Profession?> GetById(Guid Id);
        Task<Profession?> GetByName(string name);
        void Add(Profession Profession);
        void Update(Profession Profession);
        void Remove(Profession Profession);
    }
}
