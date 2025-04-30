using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.State
{
    public abstract class StateCommand : Command
    {
        public Guid Id { get; set; }	
        public string Name { get; set; }
        public string Initials { get; set; }
    }
}
