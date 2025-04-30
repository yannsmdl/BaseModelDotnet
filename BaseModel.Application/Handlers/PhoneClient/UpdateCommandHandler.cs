using BaseModel.Application.Commands.PhoneClient;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.PhoneClient
{
    public class UpdatePhoneClientCommandHandler : CommandHandler, IRequestHandler<UpdateCommand, ValidationResult>
    {
        private readonly IPhoneClientRepository _phoneClientRepository;
        private readonly IClientRepository _clientRepository;
        public UpdatePhoneClientCommandHandler
        (
            IPhoneClientRepository phoneClientRepository,
            IClientRepository clientRepository
        )
        {
            _phoneClientRepository = phoneClientRepository;
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetById(request.ClientId);
            if (client == null)
            {
                AddError("Cliente não encontrado");
                return ValidationResult;
            }
            var phoneClient = await _phoneClientRepository.GetById(request.Id);
            if (phoneClient == null)
            {
                AddError("Telefone do cliente não existe");
                return ValidationResult;
            }
            phoneClient.Update(request.Number, request.Main);
            
            _phoneClientRepository.Update(phoneClient);
            return await Commit(_phoneClientRepository.UnitOfWork);
        }
    }
}
