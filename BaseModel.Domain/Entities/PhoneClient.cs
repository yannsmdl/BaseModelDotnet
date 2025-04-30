namespace BaseModel.Domain.Entities
{
    public sealed class PhoneClient : EntityBase
    {
        public PhoneClient(Guid id, Guid clientId, string number, bool main)
        {
            Id = id;
            ClientId = clientId;
            Number = number;
            Main = main;
        }

        public void Update(string number, bool main)
        {
            Number = number;
            Main = main;
        }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        public string Number { get; private set; }
        public bool Main { get; private set; } = true;
    }
}