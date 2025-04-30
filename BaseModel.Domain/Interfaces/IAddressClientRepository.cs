using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface IAddressClientRepository : IRepository<AddressClient>
    {
        Task<IEnumerable<AddressClient>> GetAll();
        Task<AddressClient?> GetById(Guid Id);
        Task<IEnumerable<AddressClient>> GetByClientId(Guid ClientId);
        void Add(AddressClient AddressClient);
        void Update(AddressClient AddressClient);
        void Remove(AddressClient AddressClient);
    }
}
