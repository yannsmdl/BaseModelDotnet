using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Tenant
{
    public class RemoveCommand : IRequest<ValidationResult>
    {
        public Guid Id { get; set; }
        public RemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
