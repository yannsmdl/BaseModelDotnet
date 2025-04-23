using BaseModel.Domain.Entities;
using MediatR;

namespace BaseModel.Application.Queries.Categories
{
    public class GetCategoryByIdQuery : IRequest<Category?>
    {
        public Guid Id { get; set; }
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
