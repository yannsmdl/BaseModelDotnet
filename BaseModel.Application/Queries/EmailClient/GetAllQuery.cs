using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.EmailClient
{
    public class GetAllQuery : IRequest<IEnumerable<Domain.Entities.EmailClient>>
    {
    }
}
