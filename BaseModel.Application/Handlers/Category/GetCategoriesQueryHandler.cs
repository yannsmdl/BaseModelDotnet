using BaseModel.Application.Queries.Categories;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Categories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll();
        }
    }
}
