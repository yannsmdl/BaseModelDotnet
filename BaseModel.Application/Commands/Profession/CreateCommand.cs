using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Commands.Profession
{
    public class CreateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
