using AutoMapper;
using BaseModel.Application.Commands.EmailClient;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.EmailClient;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class EmailClientService : IEmailClientService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IEmailClientRepository _emailClientRepository;
        public EmailClientService(IMapper mapper, IMediator mediator, IEmailClientRepository emailClientRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _emailClientRepository = emailClientRepository;
        }

        public async Task<IEnumerable<EmailClientDTO>> GetAll()
        {
            var emailClientQuery = new GetAllQuery();
            var emailClient = await _mediator.Send(emailClientQuery);
            return _mapper.Map<IEnumerable<EmailClientDTO>>(emailClient);
        }

        public async Task<EmailClientDTO?> GetById(Guid Id)
        {
            var emailClientQuery = new GetByIdQuery(Id);
            var emailClient = await _mediator.Send(emailClientQuery);
            return _mapper.Map<EmailClientDTO>(emailClient);
        }

        public async Task<IEnumerable<EmailClientDTO>> GetByStateId(Guid ClientId)
        {
            var emailClientQuery = new GetByClientIdQuery(ClientId);
            var emailClient = await _mediator.Send(emailClientQuery);
            return _mapper.Map<IEnumerable<EmailClientDTO>>(emailClient);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var emailClientRemoveCommand = new RemoveCommand(Id);
            return await _mediator.Send(emailClientRemoveCommand);
        }

        public async Task<ValidationResult> Update(EmailClientDTO emailClient)
        {
            var emailClientUpdateCommand = _mapper.Map<UpdateCommand>(emailClient);
            return await _mediator.Send(emailClientUpdateCommand);
        }

        public async Task Add(EmailClientDTO emailClientDTO)
        {
            var emailClient = _mapper.Map<EmailClient>(emailClientDTO);
            _emailClientRepository.Add(emailClient);
        }
        public async Task RemoveByClientId(Guid clientId)
        {
            var emailClients = await _emailClientRepository.GetByClientId(clientId);
            foreach(var emailClient in emailClients)
            {
                _emailClientRepository.Remove(emailClient);
            }
        }
    }
}
