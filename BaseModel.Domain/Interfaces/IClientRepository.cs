using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client?> GetById(Guid Id);
        Task<Client?> GetByUserId(string UserId);
        void Add(Client Client);
        void Update(Client Client);
        void Remove(Client Client);
    }
}
