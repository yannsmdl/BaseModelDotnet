using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseModel.Domain.Entities
{
    public sealed class EmailClient : EntityBase
    {
        public EmailClient(Guid id, Guid clientId, string address, bool main)
        {
            Id = id;
            ClientId = clientId;
            Address = address;
            Main = main;
        }

        public void Update(string address, bool main)
        {
            Address = address;
            Main = main;
        }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        public string Address { get; private set; }
        public bool Main { get; private set; } = true;
    }
}