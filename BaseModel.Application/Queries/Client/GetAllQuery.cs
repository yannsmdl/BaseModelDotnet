using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.Client
{
    public class GetAllQuery : IRequest<IEnumerable<Domain.Entities.Client>>
    {
    }
}
