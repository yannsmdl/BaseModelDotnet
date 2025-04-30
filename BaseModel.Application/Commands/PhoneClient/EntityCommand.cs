using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.PhoneClient
{
    public abstract class EntityCommand : Command
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Guid ClientId { get; set; }
        public bool Main { get; set; } = true;
    }
}
