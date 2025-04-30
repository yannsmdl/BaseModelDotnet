using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.State
{
    public class GetStateByIdQuery : IRequest<Domain.Entities.State?>
    {
        public Guid Id { get; set; }
        public GetStateByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
