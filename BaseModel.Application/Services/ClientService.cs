using AutoMapper;
using BaseModel.Application.Commands.Client;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.Client;
using BaseModel.Application.Shareds;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ClientService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ClientDTO>> GetAll()
        {
            var clientQuery = new GetAllQuery();
            var client = await _mediator.Send(clientQuery);
            return _mapper.Map<IEnumerable<ClientDTO>>(client);
        }

        public async Task<ClientDTO?> GetById(Guid Id)
        {
            var clientQuery = new GetByIdQuery(Id);
            var client = await _mediator.Send(clientQuery);
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var clientRemoveCommand = new RemoveCommand(Id);
            return await _mediator.Send(clientRemoveCommand);
        }

        public async Task<ValidationResult> Update(ClientDTO client)
        {
            var clientUpdateCommand = _mapper.Map<UpdateCommand>(client);
            return await _mediator.Send(clientUpdateCommand);
        }

        public async Task<ValidationResultWithData<Guid>> Add(ClientDTO client)
        {
            client.Id = Guid.NewGuid();
            var clientCreateCommand = _mapper.Map<CreateCommand>(client);
            var validationResult = await _mediator.Send(clientCreateCommand);
            return new ValidationResultWithData<Guid>(validationResult, client.Id);
        }

    }
}
