using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Commands.City
{
    public class UpdateCommand : EntityCommand, IRequest<ValidationResult>
    {
    }
}
