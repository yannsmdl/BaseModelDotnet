using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface IStateRepository : IRepository<State>
    {
        Task<IEnumerable<State>> GetAll();
        Task<State?> GetById(Guid Id);
        Task<State?> GetByName(string Name);
        void Add(State State);
        void Update(State State);
        void Remove(State State);
    }
}
