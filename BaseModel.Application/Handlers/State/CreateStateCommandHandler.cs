using BaseModel.Application.Commands.State;
using BaseModel.Domain.Interfaces;
using MediatR;
using FluentValidation.Results;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.State
{
    public class CreateStateCommandHandler : CommandHandler, IRequestHandler<CreateStateCommand, ValidationResult>
    {
        private readonly IStateRepository _stateRepository;
        public CreateStateCommandHandler
        (
            IStateRepository stateRepository
        )
        {
            _stateRepository = stateRepository;
        }

        public async Task<ValidationResult> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var stateExists = await _stateRepository.GetByName(request.Name);
            if (stateExists != null)
            {
                AddError("Já existe um estado com esse nome");
                return ValidationResult;
            }
            var state = new Domain.Entities.State(
                request.Id,
                request.Name,
                request.Initials
            );
            _stateRepository.Add(state);
            return await Commit(_stateRepository.UnitOfWork);
        }
    }
}
