using BaseModel.Application.Commands.Profession;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Profession
{
    public class RemoveProfessionCommandHandler : CommandHandler, IRequestHandler<RemoveCommand, ValidationResult>
    {
        private readonly IProfessionRepository _professionRepository;
        public RemoveProfessionCommandHandler(IProfessionRepository professionRepository)
        {
            _professionRepository = professionRepository;
        }

        public async Task<ValidationResult> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var profession = await _professionRepository.GetById(request.Id);
            if (profession == null)
            {
                AddError("Profissão não existe");
                return ValidationResult;
            }
            _professionRepository.Remove(profession);
            return await Commit(_professionRepository.UnitOfWork);
        }
    }
}
