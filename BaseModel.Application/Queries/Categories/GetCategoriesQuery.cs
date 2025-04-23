using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.Categories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
