using MediatR;

namespace BaseModel.Application.Queries.Profession
{
    public class GetByIdQuery : IRequest<Domain.Entities.Profession?>
    {
        public Guid Id { get; set; }
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
