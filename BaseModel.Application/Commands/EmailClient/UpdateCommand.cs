using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.EmailClient
{
    public class UpdateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
