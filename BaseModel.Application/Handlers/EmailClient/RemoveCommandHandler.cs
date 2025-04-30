using BaseModel.Application.Commands.EmailClient;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.EmailClient
{
    public class RemoveEmailClientCommandHandler : CommandHandler, IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly IEmailClientRepository _emailClientRepository;
        public RemoveEmailClientCommandHandler(IEmailClientRepository emailClientRepository)
        {
            _emailClientRepository = emailClientRepository;
        }

        public async Task<ValidationResult> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var emailClient = await _emailClientRepository.GetById(request.Id);
            if (emailClient == null)
            {
                AddError("Email do cliente não existe");
                return ValidationResult;
            }
            _emailClientRepository.Remove(emailClient);
            return await Commit(_emailClientRepository.UnitOfWork);
        }
    }
}
