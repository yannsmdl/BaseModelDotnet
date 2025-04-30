using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.State
{
    public class GetStatesQuery : IRequest<IEnumerable<Domain.Entities.State>>
    {
    }
}
