using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.City
{
    public class GetAllQuery : IRequest<IEnumerable<Domain.Entities.City>>
    {
    }
}
