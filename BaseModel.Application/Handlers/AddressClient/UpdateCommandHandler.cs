using BaseModel.Application.Commands.AddressClient;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.AddressClient
{
    public class UpdateAddressClientCommandHandler : CommandHandler, IRequestHandler<UpdateCommand, ValidationResult>
    {
        private readonly IAddressClientRepository _addressClientRepository;
        private readonly IClientRepository _clientRepository;
        public UpdateAddressClientCommandHandler
        (
            IAddressClientRepository addressClientRepository,
            IClientRepository clientRepository
        )
        {
            _addressClientRepository = addressClientRepository;
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetById(request.ClientId);
            if (client == null)
            {
                AddError("Client not found.");
                return ValidationResult;
            }
            var addressClient = await _addressClientRepository.GetById(request.Id);
            if (addressClient == null)
            {
                throw new ApplicationException("AddressClient not exists");
            }
            addressClient.Update(request.Street, request.Number, request.Complement, request.Neighborhood, request.CityId, request.ZipCode);
            
            _addressClientRepository.Update(addressClient);
            return await Commit(_addressClientRepository.UnitOfWork);
        }
    }
}
