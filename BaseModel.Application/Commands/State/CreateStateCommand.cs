using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.State
{
    public class CreateStateCommand : StateCommand, IRequest<ValidationResult>
    {
    }
}
