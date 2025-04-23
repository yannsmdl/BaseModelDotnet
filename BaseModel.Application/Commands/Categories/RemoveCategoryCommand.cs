using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Categories
{
    public class RemoveCategoryCommand : IRequest<ValidationResult>
    {
        public Guid Id { get; set; }
        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
