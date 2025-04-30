using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.Profession
{
    public abstract class EntityCommand : Command
    {
        public Guid Id { get; set; }	
        public string Name { get; set; }
    }
}
