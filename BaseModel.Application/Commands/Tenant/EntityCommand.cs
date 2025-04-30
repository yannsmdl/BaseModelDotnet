using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.Tenant
{
    public abstract class EntityCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string TenantUrl { get; set; }
    }
}
