using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Client
{
    public class CreateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
