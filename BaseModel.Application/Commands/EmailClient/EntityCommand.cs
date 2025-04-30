using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.EmailClient
{
    public abstract class EntityCommand : Command
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public Guid ClientId { get; set; }
        public bool Main { get; set; } = true;
    }
}
