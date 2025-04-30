using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface ITenantDbContextRouteFactory
    {
        Task<IUnitOfWork> CreateAndMigrateDbContextAsync(string connectionString, CancellationToken cancellationToken);
    }
}
