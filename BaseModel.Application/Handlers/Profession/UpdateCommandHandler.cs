using BaseModel.Application.Commands.Profession;
using BaseModel.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace BaseModel.Application.Handlers.Profession
{
    public class UpdateProfessionCommandHandler : CommandHandler, IRequestHandler<UpdateCommand, ValidationResult>
    {
        private readonly IProfessionRepository _professionRepository;
        public UpdateProfessionCommandHandler
        (
            IProfessionRepository professionRepository
        )
        {
            _professionRepository = professionRepository;
        }

        public async Task<ValidationResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var profession = await _professionRepository.GetById(request.Id);
            if (profession == null)
            {
                AddError("Profissão não existe");
                return ValidationResult;
            }
            var professionExists = await _professionRepository.GetByName(request.Name);
            if (professionExists != null && professionExists.Id != profession.Id)
            {
                AddError("Já existe uma profissão com esse nome");
                return ValidationResult;
            }
            profession.Update(request.Name);
            
            _professionRepository.Update(profession);
            return await Commit(_professionRepository.UnitOfWork);
        }
    }
}
