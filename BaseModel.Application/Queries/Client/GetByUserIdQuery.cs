using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.Client
{
    public class GetByUserIdQuery : IRequest<Domain.Entities.Client?>
    {
        public string UserId { get; set; }
        public GetByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
