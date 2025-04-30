using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface IPhoneClientRepository : IRepository<PhoneClient>
    {
        Task<IEnumerable<PhoneClient>> GetAll();
        Task<PhoneClient?> GetById(Guid Id);
        Task<IEnumerable<PhoneClient>> GetByClientId(Guid ClientId);
        void Add(PhoneClient PhoneClient);
        void Update(PhoneClient PhoneClient);
        void Remove(PhoneClient PhoneClient);
    }
}
