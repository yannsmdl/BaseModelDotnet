using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.Tenant
{
    public class GetAllQuery : IRequest<IEnumerable<Domain.Entities.Tenant>>
    {
    }
}
