using AutoMapper;
using BaseModel.Application.Commands.Categories;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.Categories;
using BaseModel.Application.Shareds;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categoriesQuery = new GetCategoriesQuery();
            var categories = await _mediator.Send(categoriesQuery);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetById(Guid Id)
        {
            var categoriesQuery = new GetCategoryByIdQuery(Id);
            var categories = await _mediator.Send(categoriesQuery);
            return _mapper.Map<CategoryDTO>(categories);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var categoryRemoveCommand = new RemoveCategoryCommand(Id);
            return await _mediator.Send(categoryRemoveCommand);
        }

        public async Task<ValidationResult> Update(CategoryDTO category)
        {
            var categoryUpdateCommand = _mapper.Map<UpdateCategoryCommand>(category);
            return await _mediator.Send(categoryUpdateCommand);
        }

        public async Task<ValidationResultWithData<Guid>> Add(CategoryDTO category)
        {
            category.Id = Guid.NewGuid();
            var categoryCreateCommand = _mapper.Map<CreateCategoryCommand>(category);
            var validationResult = await _mediator.Send(categoryCreateCommand);
            return new ValidationResultWithData<Guid>(validationResult, category.Id);
        }
    }
}
