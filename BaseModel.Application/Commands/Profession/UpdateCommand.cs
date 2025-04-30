using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.Profession
{
    public class UpdateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
