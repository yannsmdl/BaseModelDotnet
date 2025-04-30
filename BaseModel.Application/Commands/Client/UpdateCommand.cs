using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Client
{
    public class UpdateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
