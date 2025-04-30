using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.City
{
    public class CreateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
