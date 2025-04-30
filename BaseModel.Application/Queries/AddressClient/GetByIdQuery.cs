using MediatR;

namespace BaseModel.Application.Queries.AddressClient
{
    public class GetByIdQuery : IRequest<Domain.Entities.AddressClient?>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
