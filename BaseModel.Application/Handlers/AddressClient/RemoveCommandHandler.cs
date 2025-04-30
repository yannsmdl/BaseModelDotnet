using BaseModel.Application.Commands.AddressClient;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.AddressClient
{
    public class RemoveAddressClientCommandHandler : CommandHandler, IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly IAddressClientRepository _addressClientRepository;
        public RemoveAddressClientCommandHandler(IAddressClientRepository addressClientRepository)
        {
            _addressClientRepository = addressClientRepository;
        }

        public async Task<ValidationResult> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var addressClient = await _addressClientRepository.GetById(request.Id);
            if (addressClient == null)
            {
                throw new ApplicationException("AddressClient not exists");
            }
            _addressClientRepository.Remove(addressClient);
            return await Commit(_addressClientRepository.UnitOfWork);
        }
    }
}
