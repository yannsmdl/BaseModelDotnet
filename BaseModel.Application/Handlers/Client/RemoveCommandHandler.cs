using BaseModel.Application.Commands.Client;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using BaseModel.Application.Interfaces;
using BaseModel.Domain.Account;

namespace BaseModel.Application.Handlers.Client
{
    public class RemoveClientCommandHandler : CommandHandler, IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressClientService _addressClientService;
        private readonly IPhoneClientService _phoneClientService;
        private readonly IEmailClientService _emailClientService;
        private readonly IAuthenticate _authenticate;
        public RemoveClientCommandHandler
        (
            IClientRepository clientRepository,
            IAddressClientService addressClientService,
            IEmailClientService emailClientService,
            IPhoneClientService phoneClientService,
            IAuthenticate authenticate
        )
        {
            _authenticate = authenticate;
            _clientRepository = clientRepository;
            _phoneClientService = phoneClientService;
            _addressClientService = addressClientService;
            _emailClientService = emailClientService;
        }

        public async Task<ValidationResult> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetById(request.Id);
            if (client == null)
            {
                AddError("Cliente não existe");
                return ValidationResult;
            }
            await _emailClientService.RemoveByClientId(client.Id);
            await _addressClientService.RemoveByClientId(client.Id);
            await _phoneClientService.RemoveByClientId(client.Id);
            await _authenticate.DeleteUser(client.UserId);
            _clientRepository.Remove(client);
            await Commit(_clientRepository.UnitOfWork);
            await _authenticate.Commit();
            return ValidationResult;
        }
    }
}
