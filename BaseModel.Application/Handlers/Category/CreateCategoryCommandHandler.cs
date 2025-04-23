using BaseModel.Application.Commands.Categories;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using MediatR;
using FluentValidation.Results;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Categories
{
    public class CreateCategoryCommandHandler : CommandHandler, IRequestHandler<CreateCategoryCommand, ValidationResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler
        (
            ICategoryRepository categoryRepository
        )
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ValidationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(
                request.Id,
                request.Name
            );
            _categoryRepository.Add(category);
            return await Commit(_categoryRepository.UnitOfWork);
        }
    }
}
