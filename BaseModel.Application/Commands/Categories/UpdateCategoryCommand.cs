using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Categories
{
    public class UpdateCategoryCommand : CategoryCommand, IRequest<ValidationResult>
    {
    }
}
