using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.PhoneClient
{
    public class GetAllQuery : IRequest<IEnumerable<Domain.Entities.PhoneClient>>
    {
    }
}
