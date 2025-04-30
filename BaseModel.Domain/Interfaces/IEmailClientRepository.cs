using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface IEmailClientRepository : IRepository<EmailClient>
    {
        Task<IEnumerable<EmailClient>> GetAll();
        Task<EmailClient?> GetById(Guid Id);
        Task<IEnumerable<EmailClient>> GetByClientId(Guid ClientId);
        void Add(EmailClient EmailClient);
        void Update(EmailClient EmailClient);
        void Remove(EmailClient EmailClient);
    }
}
