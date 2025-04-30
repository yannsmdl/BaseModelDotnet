using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.State
{
    public class UpdateStateCommand : StateCommand, IRequest<ValidationResult>
    {
    }
}
