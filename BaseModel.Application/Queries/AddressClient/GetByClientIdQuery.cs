using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.AddressClient
{
    public class GetByClientIdQuery : IRequest<IEnumerable<Domain.Entities.AddressClient>>
    {
        public Guid ClientId { get; set; }
        public GetByClientIdQuery(Guid stateId)
        {
            ClientId = stateId;
        }
    }
}
