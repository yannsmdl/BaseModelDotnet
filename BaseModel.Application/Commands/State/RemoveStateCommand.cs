using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.State
{
    public class RemoveStateCommand : IRequest<ValidationResult>
    {
        public Guid Id { get; set; }
        public RemoveStateCommand(Guid id)
        {
            Id = id;
        }
    }
}
