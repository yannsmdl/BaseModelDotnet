using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.AddressClient
{
    public abstract class EntityCommand : Command
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public Guid CityId { get; set; }
        public Guid ClientId { get; set; }
        public string ZipCode { get; set; }
    }
}
