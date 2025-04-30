using AutoMapper;
using BaseModel.Application.Commands.State;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.State;
using BaseModel.Application.Shareds;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public StateService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<StateDTO>> GetAll()
        {
            var stateQuery = new GetStatesQuery();
            var state = await _mediator.Send(stateQuery);
            return _mapper.Map<IEnumerable<StateDTO>>(state);
        }

        public async Task<StateDTO?> GetById(Guid Id)
        {
            var stateQuery = new GetStateByIdQuery(Id);
            var state = await _mediator.Send(stateQuery);
            return _mapper.Map<StateDTO>(state);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var stateRemoveCommand = new RemoveStateCommand(Id);
            return await _mediator.Send(stateRemoveCommand);
        }

        public async Task<ValidationResult> Update(StateDTO state)
        {
            var stateUpdateCommand = _mapper.Map<UpdateStateCommand>(state);
            return await _mediator.Send(stateUpdateCommand);
        }

        public async Task<ValidationResultWithData<Guid>> Add(StateDTO state)
        {
            state.Id = Guid.NewGuid();
            var stateCreateCommand = _mapper.Map<CreateStateCommand>(state);
            var validationResult = await _mediator.Send(stateCreateCommand);
            return new ValidationResultWithData<Guid>(validationResult, state.Id);
        }
    }
}
