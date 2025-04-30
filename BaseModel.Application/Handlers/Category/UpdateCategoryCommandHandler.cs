using BaseModel.Application.Commands.Categories;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Categories
{
    public class UpdateCategoryCommandHandler : CommandHandler, IRequestHandler<UpdateCategoryCommand, ValidationResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler
        (
            ICategoryRepository categoryRepository
        )
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ValidationResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            if (category == null)
            {
                AddError("Categoria não existe");
                return ValidationResult;
            }
            category.SetName(request.Name);
            
            _categoryRepository.Update(category);
            return await Commit(_categoryRepository.UnitOfWork);
        }
    }
}
