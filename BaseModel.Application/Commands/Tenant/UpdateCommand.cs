using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Tenant
{
    public class UpdateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
