using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.City
{
    public class GetByStateIdQuery : IRequest<IEnumerable<Domain.Entities.City>>
    {
        public Guid StateId { get; set; }
        public GetByStateIdQuery(Guid stateId)
        {
            StateId = stateId;
        }
    }
}
