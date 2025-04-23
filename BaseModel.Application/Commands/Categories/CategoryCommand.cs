using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.Categories
{
    public abstract class CategoryCommand : Command
    {
        public Guid Id { get; set; }	
        public string Name { get; set; }
    }
}
