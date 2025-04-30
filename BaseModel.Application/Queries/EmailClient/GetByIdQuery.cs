using MediatR;

namespace BaseModel.Application.Queries.EmailClient
{
    public class GetByIdQuery : IRequest<Domain.Entities.EmailClient?>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
