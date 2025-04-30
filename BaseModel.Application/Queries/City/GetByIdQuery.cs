using MediatR;

namespace BaseModel.Application.Queries.City
{
    public class GetByIdQuery : IRequest<Domain.Entities.City?>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
