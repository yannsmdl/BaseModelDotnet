using AutoMapper;
using BaseModel.Application.Commands.AddressClient;
using BaseModel.Application.DTOs;
using BaseModel.Application.Interfaces;
using BaseModel.Application.Queries.AddressClient;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace BaseModel.Application.Services
{
    public class AddressClientService : IAddressClientService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IAddressClientRepository _addressClientRepository;
        public AddressClientService(IMapper mapper, IMediator mediator, IAddressClientRepository addressClientRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _addressClientRepository = addressClientRepository;
        }

        public async Task<IEnumerable<AddressClientDTO>> GetAll()
        {
            var addressClientQuery = new GetAllQuery();
            var addressClient = await _mediator.Send(addressClientQuery);
            return _mapper.Map<IEnumerable<AddressClientDTO>>(addressClient);
        }

        public async Task<AddressClientDTO?> GetById(Guid Id)
        {
            var addressClientQuery = new GetByIdQuery(Id);
            var addressClient = await _mediator.Send(addressClientQuery);
            return _mapper.Map<AddressClientDTO>(addressClient);
        }

        public async Task<IEnumerable<AddressClientDTO>> GetByStateId(Guid ClientId)
        {
            var addressClientQuery = new GetByClientIdQuery(ClientId);
            var addressClient = await _mediator.Send(addressClientQuery);
            return _mapper.Map<IEnumerable<AddressClientDTO>>(addressClient);
        }

        public async Task<ValidationResult> Remove(Guid Id)
        {
            var addressClientRemoveCommand = new RemoveCommand(Id);
            return await _mediator.Send(addressClientRemoveCommand);
        }

        public async Task<ValidationResult> Update(AddressClientDTO addressClient)
        {
            var addressClientUpdateCommand = _mapper.Map<UpdateCommand>(addressClient);
            return await _mediator.Send(addressClientUpdateCommand);
        }

        public async Task Add(AddressClientDTO addressClientDTO)
        {
            var addressClient = _mapper.Map<AddressClient>(addressClientDTO);
            _addressClientRepository.Add(addressClient);
        }

        public async Task RemoveByClientId(Guid clientId)
        {
            var addressesClient = await _addressClientRepository.GetByClientId(clientId);
            foreach(var addressClient in addressesClient)
            {
                _addressClientRepository.Remove(addressClient);
            }
        }
    }
}
