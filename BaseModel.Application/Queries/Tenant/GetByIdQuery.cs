using MediatR;

namespace BaseModel.Application.Queries.Tenant
{
    public class GetByIdQuery : IRequest<Domain.Entities.Tenant?>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
