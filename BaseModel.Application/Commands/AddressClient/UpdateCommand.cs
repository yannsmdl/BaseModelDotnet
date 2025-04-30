using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.AddressClient
{
    public class UpdateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
