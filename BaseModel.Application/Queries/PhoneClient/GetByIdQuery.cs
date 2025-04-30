using MediatR;

namespace BaseModel.Application.Queries.PhoneClient
{
    public class GetByIdQuery : IRequest<Domain.Entities.PhoneClient?>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
