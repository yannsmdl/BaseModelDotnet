using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Categories
{
    public class CreateCategoryCommand : CategoryCommand, IRequest<ValidationResult>
    {
    }
}
