using BaseModel.Application.Queries.Categories;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using MediatR;

namespace BaseModel.Application.Handlers.Categories
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category?>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetById(request.Id);
        }
    }
}
