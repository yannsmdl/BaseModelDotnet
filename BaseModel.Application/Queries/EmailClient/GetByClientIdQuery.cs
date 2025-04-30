using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.EmailClient
{
    public class GetByClientIdQuery : IRequest<IEnumerable<Domain.Entities.EmailClient>>
    {
        public Guid ClientId { get; set; }
        public GetByClientIdQuery(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
