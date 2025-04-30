using MediatR;

namespace BaseModel.Application.Queries.Client
{
    public class GetByIdQuery : IRequest<Domain.Entities.Client?>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
