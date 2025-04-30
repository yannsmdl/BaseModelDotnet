using BaseModel.Application.Commands.PhoneClient;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.PhoneClient
{
    public class RemovePhoneClientCommandHandler : CommandHandler, IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly IPhoneClientRepository _phoneClientRepository;
        public RemovePhoneClientCommandHandler(IPhoneClientRepository phoneClientRepository)
        {
            _phoneClientRepository = phoneClientRepository;
        }

        public async Task<ValidationResult> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var phoneClient = await _phoneClientRepository.GetById(request.Id);
            if (phoneClient == null)
            {
                AddError("Telefone do cliente não existe");
                return ValidationResult;
            }
            _phoneClientRepository.Remove(phoneClient);
            return await Commit(_phoneClientRepository.UnitOfWork);
        }
    }
}
