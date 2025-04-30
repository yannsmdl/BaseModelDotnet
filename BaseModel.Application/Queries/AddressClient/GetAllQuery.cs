using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.AddressClient
{
    public class GetAllQuery : IRequest<IEnumerable<Domain.Entities.AddressClient>>
    {
    }
}
