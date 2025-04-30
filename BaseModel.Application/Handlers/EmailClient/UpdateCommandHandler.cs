using BaseModel.Application.Commands.EmailClient;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.EmailClient
{
    public class UpdateEmailClientCommandHandler : CommandHandler, IRequestHandler<UpdateCommand, ValidationResult>
    {
        private readonly IEmailClientRepository _emailClientRepository;
        private readonly IClientRepository _clientRepository;
        public UpdateEmailClientCommandHandler
        (
            IEmailClientRepository emailClientRepository,
            IClientRepository clientRepository
        )
        {
            _emailClientRepository = emailClientRepository;
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetById(request.ClientId);
            if (client == null)
            {
                AddError("Client não encontrado");
                return ValidationResult;
            }
            var emailClient = await _emailClientRepository.GetById(request.Id);
            if (emailClient == null)
            {
                AddError("Email do cliente não existe");
                return ValidationResult;
            }
            emailClient.Update(request.Address, request.Main);
            
            _emailClientRepository.Update(emailClient);
            return await Commit(_emailClientRepository.UnitOfWork);
        }
    }
}
