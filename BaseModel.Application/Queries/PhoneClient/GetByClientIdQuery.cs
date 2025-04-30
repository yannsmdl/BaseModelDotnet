using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.PhoneClient
{
    public class GetByClientIdQuery : IRequest<IEnumerable<Domain.Entities.PhoneClient>>
    {
        public Guid ClientId { get; set; }
        public GetByClientIdQuery(Guid stateId)
        {
            ClientId = stateId;
        }
    }
}
