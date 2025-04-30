using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.PhoneClient
{
    public class UpdateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
