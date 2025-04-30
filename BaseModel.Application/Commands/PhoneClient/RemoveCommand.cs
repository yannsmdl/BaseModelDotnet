using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.PhoneClient
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
