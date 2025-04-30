using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.Tenant
{
    public class CreateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
