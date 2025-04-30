using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.City
{
    public abstract class EntityCommand : Command
    {
        public Guid Id { get; set; }	
        public string Name { get; set; }
        public Guid StateId { get; set; }
        public string IbgeId { get; set; }
    }
}
