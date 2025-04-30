using BaseModel.Application.Commands.State;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.State
{
    public class UpdateStateCommandHandler : CommandHandler, IRequestHandler<UpdateStateCommand, ValidationResult>
    {
        private readonly IStateRepository _stateRepository;
        public UpdateStateCommandHandler
        (
            IStateRepository stateRepository
        )
        {
            _stateRepository = stateRepository;
        }

        public async Task<ValidationResult> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var state = await _stateRepository.GetById(request.Id);
            if (state == null)
            {
                AddError("Estado não existe");
                return ValidationResult;
            }
            state.Update(request.Name, request.Initials);
            
            _stateRepository.Update(state);
            return await Commit(_stateRepository.UnitOfWork);
        }
    }
}
