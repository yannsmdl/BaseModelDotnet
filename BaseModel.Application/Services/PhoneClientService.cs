using AutoMapper;
using BaseModel.Application.Commands.PhoneClient;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.PhoneClient;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class PhoneClientService : IPhoneClientService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPhoneClientRepository _phoneClientRepository;
        public PhoneClientService(IMapper mapper, IMediator mediator, IPhoneClientRepository phoneClientRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _phoneClientRepository = phoneClientRepository;
        }

        public async Task<IEnumerable<PhoneClientDTO>> GetAll()
        {
            var phoneClientQuery = new GetAllQuery();
            var phoneClient = await _mediator.Send(phoneClientQuery);
            return _mapper.Map<IEnumerable<PhoneClientDTO>>(phoneClient);
        }

        public async Task<PhoneClientDTO?> GetById(Guid Id)
        {
            var phoneClientQuery = new GetByIdQuery(Id);
            var phoneClient = await _mediator.Send(phoneClientQuery);
            return _mapper.Map<PhoneClientDTO>(phoneClient);
        }

        public async Task<IEnumerable<PhoneClientDTO>> GetByStateId(Guid ClientId)
        {
            var phoneClientQuery = new GetByClientIdQuery(ClientId);
            var phoneClient = await _mediator.Send(phoneClientQuery);
            return _mapper.Map<IEnumerable<PhoneClientDTO>>(phoneClient);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var phoneClientRemoveCommand = new RemoveCommand(Id);
            return await _mediator.Send(phoneClientRemoveCommand);
        }

        public async Task<ValidationResult> Update(PhoneClientDTO phoneClient)
        {
            var phoneClientUpdateCommand = _mapper.Map<UpdateCommand>(phoneClient);
            return await _mediator.Send(phoneClientUpdateCommand);
        }

        public async Task Add(PhoneClientDTO phoneClientDTO)
        {
            var phoneClient = _mapper.Map<PhoneClient>(phoneClientDTO);
            _phoneClientRepository.Add(phoneClient);
        }
        public async Task RemoveByClientId(Guid clientId)
        {
            var phoneClients = await _phoneClientRepository.GetByClientId(clientId);
            foreach(var phoneClient in phoneClients)
            {
                _phoneClientRepository.Remove(phoneClient);
            }
        }
    }
}
