using BaseModel.Application.Commands.State;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.State
{
    public class RemoveStateCommandHandler : CommandHandler, IRequestHandler<RemoveStateCommand, ValidationResult>
    {
        private readonly IStateRepository _stateRepository;
        public RemoveStateCommandHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<ValidationResult> Handle(RemoveStateCommand request, CancellationToken cancellationToken)
        {
            var state = await _stateRepository.GetById(request.Id);
            if (state == null)
            {
                AddError("Estado não existe");
                return ValidationResult;
            }
            _stateRepository.Remove(state);
            return await Commit(_stateRepository.UnitOfWork);
        }
    }
}
