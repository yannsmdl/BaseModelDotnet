using BaseModel.Application.Commands.Profession;
using BaseModel.Domain.Interfaces;
using MediatR;
using FluentValidation.Results;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Profession
{
    public class CreateProfessionCommandHandler : CommandHandler, IRequestHandler<CreateCommand, ValidationResult>
    {
        private readonly IProfessionRepository _professionRepository;
        public CreateProfessionCommandHandler
        (
            IProfessionRepository professionRepository
        )
        {
            _professionRepository = professionRepository;
        }

        public async Task<ValidationResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var professionExists = await _professionRepository.GetByName(request.Name);
            if (professionExists != null)
            {
                AddError("Já existe uma profissão com esse nome");
                return ValidationResult;
            }
            var profession = new Domain.Entities.Profession(
                request.Id,
                request.Name
            );
            _professionRepository.Add(profession);
            return await Commit(_professionRepository.UnitOfWork);
        }
    }
}
