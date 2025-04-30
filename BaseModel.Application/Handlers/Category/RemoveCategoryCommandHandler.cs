using BaseModel.Application.Commands.Categories;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Categories
{
    public class RemoveCategoryCommandHandler : CommandHandler, IRequestHandler<RemoveCategoryCommand, ValidationResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ValidationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            if (category == null)
            {
                AddError("Categoria não existe");
                return ValidationResult;
            }
            _categoryRepository.Remove(category);
            return await Commit(_categoryRepository.UnitOfWork);
        }
    }
}
