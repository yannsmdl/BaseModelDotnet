using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.Profession
{
    public class GetAllQuery : IRequest<IEnumerable<Domain.Entities.Profession>>
    {
    }
}
